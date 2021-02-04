using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models;
using ComissionBank.Data;
using System.IO;
using ComissionBank.Services.Exceptions;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ComissionBank.Services
{
    
    public class PanService
    {
        private readonly ComissionBankContext _context;

        public PanService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }

        public double GetTotal()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            month = 12;
            year = 2018;

            double totalPan = _context.Pan.Where(x => x.Date.Month == month).Where(x => x.Date.Year == year).Sum(x => x.BankValue);

            return totalPan;
        }

        public double GetTotalAdvisor(int id)
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            month = 12;
            year = 2018;

            double totalPan = _context.Pan.Where(x => x.AdvisorId == id).Where(x => x.Date.Month == month).Where(x => x.Date.Year == year).Sum(x => x.BankValue);

            return totalPan;
        }
        public void Insert(Pan pan)
        {
            _context.Pan.Add(pan);
            _context.SaveChanges();
        }

        public void Remove(Pan pan)
        {
            _context.Remove(pan);
            _context.SaveChanges();
        }

        public void Update(Pan pan)
        {
            if(!_context.Pan.Any(x => x.Id == pan.Id))
            {
                throw new Exception("Pan não encontrada!");
            }

            try
            {
                _context.Update(pan);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public List<Pan> FindAll()
        {
            return _context.Pan.ToList();
        }

        public List<Pan> Top(int num)
        {
            return _context.Pan.Take(num).ToList();
        }
        public Pan FindById(int id)
        {
            return _context.Pan.FirstOrDefault(x => x.Id == id);
        }

        public List<Pan> Import()
        {
            string path = @"c:\temp\pan.csv";
            List<Pan> pans = new List<Pan>();

            using (StreamReader streamReader = File.OpenText(path))
            {
                streamReader.ReadLine();

                while (!streamReader.EndOfStream)
                {
                    char[] delimiterChars = { ';' };
                    string[] fields = streamReader.ReadLine().Split(delimiterChars);

                    if(fields[0] == "")
                    {
                        break;
                    }

                    string[] removeChars = { "R$", "-", " " };
                    
                    DateTime datePan = DateTime.Parse(fields[1], CultureInfo.CreateSpecificCulture("pt-BR"), DateTimeStyles.None);

                    string clientCode = fields[2].Trim();
                    string clientName = fields[3];
                    string advisorInitials = fields[4].Trim();

                    int clientId = _context.Client.Where(x => x.Name == clientName).Select(x => x.Id).FirstOrDefault();
                    if(clientId == 0)
                    {
                        Client client = new Client(clientName, advisorInitials);

                        _context.Client.Add(client);
                        try
                        {
                            _context.SaveChanges();
                        }
                        catch(Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                        clientId = _context.Client.Where(x => x.AdvisorInitials == advisorInitials).Select(x => x.Id).FirstOrDefault();
                    }

                    //----------- Tratamento Advisor -----------------------------
                    int advisorId = _context.Advisor.Where(x => x.Initials == advisorInitials).Select(x => x.Id).FirstOrDefault();
                    if(advisorId == 0)
                    {
                        Advisor advisor = new Advisor(advisorInitials);

                        _context.Advisor.Add(advisor);
                        try
                        {
                            _context.SaveChanges();
                        }
                        catch(Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                        advisorId = _context.Advisor.Where(x => x.Initials == advisorInitials).Select(x => x.Id).FirstOrDefault();
                    }

                    double panValue = GetDouble(fields[5]);
                    double panLiquidValue = GetDouble(fields[6]);
                    double netAdvisorValue = GetDouble(fields[7]);
                    double bankValue = GetDouble(fields[8]);

                    Pan newPan = new Pan(datePan, clientCode, clientName, advisorInitials, panValue, panLiquidValue, netAdvisorValue, bankValue);
                    pans.Add(newPan);

                    Pan newPan1 = new Pan(datePan, clientCode, clientName, clientId, advisorId, advisorInitials, panValue, panLiquidValue, netAdvisorValue, bankValue);
                    Insert(newPan1);

                    
                }
            }

            return pans;
        }

        public static double GetDouble(string strDouble)
        {
            var numbers = new Regex(@"[^\d]");
            double resultDoubleConversion;

            string strResult = numbers.Replace(strDouble, "");
            var isValidComission = double.TryParse(strResult, out resultDoubleConversion);

            double doubleResult = (isValidComission ? resultDoubleConversion : 0) ;

            return doubleResult;
        }

    }
}
