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
        private readonly AdvisorService _advisorService;
        private readonly ProductService _productService;

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

                    string broker           = fields[0].Trim();
                    DateTime data           = DateTime.Parse(fields[0], CultureInfo.CreateSpecificCulture("pt-BR"), DateTimeStyles.None);
                    string clientName       = fields[2].Trim();
                    
                    string house            = fields[3].Trim();
                    int houseId             = _houseService.GetIdByName(house);
                    
                    string advisorInitials  = fields[4].Trim();
                    
                    int clientId            = _clientService.GetIdByAdvisorInitials(advisorInitials);
                    if (clientId == 0)
                    {
                        Client client = new Client(clientName, advisorInitials);
                        _clientService.Insert(client);
                        clientId = _clientService.GetIdByAdvisorInitials(advisorInitials);  
                    }

                    int advisorId   = _advisorService.GetIdByInitials(advisorInitials);

                    string product  = fields[7].Trim();
                    int productId   = _productService.GetIdByName(product);

                    string strValue = fields[8].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ");
                    double value    = double.Parse(strValue, CultureInfo.CreateSpecificCulture("pt-BR"));

                    string strLiquidValue   = fields[9].Trim().Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ");
                    double liquidValue      = double.Parse(strLiquidValue, CultureInfo.CreateSpecificCulture("pt-BR"));

                    string strNetValue  = fields[10].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ");
                    double netValue     = double.Parse(strNetValue, CultureInfo.CreateSpecificCulture("pt-BR"));

                    string strAvisorValue   = fields[11].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ");
                    double advisorValue     = double.Parse(strAvisorValue, CultureInfo.CreateSpecificCulture("pt-BR"));

                    int month   = int.Parse(fields[12].Trim());
                    int year    = int.Parse(fields[13].Trim());
                }
            }

            return protects;
        }
    }
}
