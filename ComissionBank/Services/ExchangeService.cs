using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;
using Microsoft.EntityFrameworkCore;
using ComissionBank.Services.Exceptions;
using System.IO;
using System.Globalization;

namespace ComissionBank.Services
{ 
    public class ExchangeService
    {
        private readonly ComissionBankContext _context;
        private readonly AdvisorService _advisorService;
        private readonly ClientService _clientService;

        public ExchangeService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }

        public void Insert(Exchange exchange)
        {
            _context.Exchange.Add(exchange);
            _context.SaveChanges(); 
        }

        public void Remove(int id)
        {
            var obj = _context.Exchange.Find(id);
            _context.Exchange.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Exchange exchange)
        {
            if(!_context.Exchange.Any(x => x.Id == exchange.Id))
            {
                throw new Exception("Câmbio não encontrado");
            }

            try
            {
                _context.Update(exchange);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public List<Exchange> FindAll()
        {
            return _context.Exchange.ToList(); 
        }

        public Exchange FindById(int id)
        {
            return _context.Exchange.FirstOrDefault(x => x.Id == id);
        }

        public List<Exchange> Import()
        {
            string path = @"c:\temp\cambio.csv";
            List<Exchange> exchanges = new List<Exchange>();

            using (StreamReader streamReader = File.OpenText(path))
            {
                streamReader.ReadLine();

                while (!streamReader.EndOfStream)
                {
                    char[] delimiterChars = { ';'};
                    string[] fields = streamReader.ReadLine().Split(delimiterChars);

                    string data = fields[0];
                    string cpf = fields[1];
                    string name = fields[2];
                    string advisorInitials = fields[3].Trim();

                    if (!_context.Client.Any(x => x.Name == name))
                    {
                        Client newClient = new Client(name, cpf, advisorInitials);
                    }

                    int clientId = _clientService.GetIdByName(name);

                    if (! _context.Advisor.Any(x => x.Initials == advisorInitials)){
                        Advisor newAdvisor = new Advisor(name, advisorInitials, cpf);
                        _advisorService.Insert(newAdvisor);
                    }

                    int advisorId = _advisorService.GetIdByInitials(advisorInitials);

                    string house = fields[4];
                    string order = fields[5];
                    string currency = fields[6];
                    string strGrossValue = fields[3].Trim().Replace('$',' ');
                    //string strGrossValue = " $1.556.344,15 ".Trim().Replace('$',' ');
                    double grossValue = double.Parse(strGrossValue);
                    exchanges.Add(new Exchange(cpf, name, grossValue));
                    
                }
            }

            return exchanges;
            
        }

    }
}
