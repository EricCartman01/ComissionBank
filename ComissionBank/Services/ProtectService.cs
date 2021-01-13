using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;
using ComissionBank.Services.Exceptions;
using System.IO;
using System.Globalization;

namespace ComissionBank.Services
{
    public class ProtectService
    {
        private readonly ComissionBankContext _context;
        private readonly ClientService _clientService;
        private readonly HouseService _houseService;

        public ProtectService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }

        public Protect FindById(int id)
        {
            return _context.Protect.FirstOrDefault(x => x.Id == id);
        }
        public void Insert(Protect protect)
        {
            _context.Protect.Add(protect);
            _context.SaveChanges();
           
        }

        public void Remove(Protect protect)
        {
            _context.Protect.Remove(protect);
            _context.SaveChanges();
        }

        public void Update(Protect protect)
        {
            if(!_context.Protect.Any(x => x.Id == protect.Id))
            {
                throw new Exception("Comissão Protect não encontrada!");
            }

            try
            {
                _context.Update(protect);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public List<Protect> FindAll()
        {
            return _context.Protect.ToList();
        }

        public List<Protect> Import()
        {
            string path = @"c:\temp\protect.csv";
            List<Protect> protects = new List<Protect>();

            using(StreamReader streamReader = File.OpenText(path))
            {
                streamReader.ReadLine();

                while (!streamReader.EndOfStream)
                {
                    string[] fields = streamReader.ReadLine().Split(";");

                    if(fields[0] == "")
                    {
                        break;
                    }

                    DateTime data           = DateTime.Parse(fields[0], CultureInfo.CreateSpecificCulture("pt-BR"), DateTimeStyles.None);
                    string clientName       = fields[1].Trim();
                    string house            = fields[2].Trim();
                    string advisorInitials  = fields[3].Trim();
                    
                    int clientId            = _clientService.GetIdByAdvisorInitials(advisorInitials);
                    if (clientId == 0)
                    {
                        Client client = new Client(clientName, advisorInitials);
                        _clientService.Insert(client);
                        clientId = _clientService.GetIdByAdvisorInitials(advisorInitials);  
                    }

                    int houseId = _houseService.GetIdByName(house);




                }
            }

            return protects;
        }
    }
}
