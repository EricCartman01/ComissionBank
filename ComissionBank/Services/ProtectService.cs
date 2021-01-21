using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;
using ComissionBank.Services.Exceptions;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ComissionBank.Services
{
    public class ProtectService
    {
        private readonly ComissionBankContext _context;

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
                    DateTime protectDate    = DateTime.Parse(fields[0], CultureInfo.CreateSpecificCulture("pt-BR"), DateTimeStyles.None);
                    string clientName       = fields[2].Trim();
                    string houseName        = fields[3].Trim();
                    int houseId             = _context.House.Where(x => x.Name == houseName).Select(x => x.Id).FirstOrDefault();
                    string advisorInitials  = fields[4].Trim();
                    
                    int clientId            = _context.Client.Where(x => x.AdvisorInitials == advisorInitials).Select(x => x.Id).FirstOrDefault();
                    if (clientId == 0)
                    {
                        Client client = new Client(clientName, advisorInitials);

                        _context.Client.Add(client);
                        try
                        {
                            _context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                        clientId = _context.Client.Where(x => x.AdvisorInitials == advisorInitials).Select(x => x.Id).FirstOrDefault();
                    }

                    int advisorId = _context.Advisor.Where(x => x.Initials == advisorInitials).Select(x => x.Id).FirstOrDefault();
                    if (advisorId == 0)
                    {
                        Advisor advisor = new Advisor(advisorInitials);

                        _context.Advisor.Add(advisor);
                        try
                        {
                            _context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                        advisorId = _context.Advisor.Where(x => x.Initials == advisorInitials).Select(x => x.Id).FirstOrDefault();
                    }

                    string productName  = fields[7].Trim();
                    int productId   = _context.Product.Where(x => x.Name == productName).Select(x => x.Id).FirstOrDefault();

                    double value = GetDouble(fields[8]);
                    double liquidValue = GetDouble(fields[9]);
                    double netValue = GetDouble(fields[10]) / 100;
                    double advisorValue = GetDouble(fields[11]);

                    int month = int.Parse(fields[12].Trim());
                    int year = int.Parse(fields[13].Trim());

                    protects.Add(new Protect(protectDate, clientName, clientId, houseId, advisorId, advisorInitials, productId, value, liquidValue, netValue, advisorValue, month, year));
                }
            }

            /*foreach (Protect item in protects)
            {
                Insert(item);
            }*/
            return protects;
        }
        public static double GetDouble(string strDouble)
        {
            var numbers = new Regex(@"[^\d]");
            double resultDoubleConversion;

            string strResult = numbers.Replace(strDouble, "");
            var isValidComission = double.TryParse(strResult, out resultDoubleConversion);

            double doubleResult = (isValidComission ? resultDoubleConversion : 0);

            return doubleResult;
        }
    }
}
