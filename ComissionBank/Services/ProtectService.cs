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

        public double GetTotal()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            month = 12;
            year = 2018;

            double totalProtect = _context.Protect.Where(x => x.Date.Month == month).Where(x => x.Date.Year == year).Sum(x => x.BankValue);

            return totalProtect;
        }

        public double GetTotalAdvisor(int id)
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            month = 12;
            year = 2018;

            double totalProtect = _context.Protect.Where(x => x.AdvisorId == id).Where(x => x.Date.Month == month).Where(x => x.Date.Year == year).Sum(x => x.BankValue);

            return totalProtect;
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

        public List<Protect> Top(int num)
        {
            return _context.Protect.Take(num).ToList();
        }
        public void Import()
        {
            string path = @"c:\temp\protect.csv";

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

                    DateTime protectDate    = DateTime.Parse(fields[1], CultureInfo.CreateSpecificCulture("pt-BR"), DateTimeStyles.None);
                    string clientName       = fields[2].Trim();
                    string houseName        = fields[5].Trim();
                    
                    int houseId             = _context.House.Where(x => x.Name.Contains(houseName)).Select(x => x.Id).FirstOrDefault();
                    if(houseId == 0)
                    {
                        houseId = 26;
                    }
                    
                    string advisorInitials  = fields[6].Trim();
                    
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
                    
                    int productId   = _context.Product.Where(x => x.Name.Contains(productName)).Select(x => x.Id).FirstOrDefault();
                    if(productId == 0)
                    {
                        productId = 117;
                    }

                    double protectValue = GetDouble(fields[8]);
                    double protectLiquidValue = GetDouble(fields[9]);
                    double netAdvisorValue = GetDouble(fields[10]) / 100;
                    double bankValue = GetDouble(fields[11]);
                    double advisorValue = GetDouble(fields[12]);

                    int month = GetInt(fields[13]);
                    int year = GetInt(fields[14]);

                    Protect protect = new Protect(protectDate, clientName, clientId, houseId, advisorId, advisorInitials, productId, protectValue, protectLiquidValue, netAdvisorValue, bankValue, advisorValue, month, year);
                    Insert(protect);
                }
            }

        }
        public static double GetDouble(string strDouble)
        {
            var numbers = new Regex(@"[^\d]");
            string strResult = numbers.Replace(strDouble, "");

            double resultDoubleConversion;
            var isValidComission = double.TryParse(strResult, out resultDoubleConversion);

            double doubleResult = (isValidComission ? resultDoubleConversion : 0);
            return doubleResult;
        }

        public static int GetInt(string str)
        {
            var alphanumeric = new Regex(@"^\D");
            string strResult = alphanumeric.Replace(str, "").Trim();
            
            int resultIntConversion;
            var isValidNumber = int.TryParse(strResult, out resultIntConversion);

            int intResult = (isValidNumber ? resultIntConversion : 0);
            return intResult;

        }
    }
}
