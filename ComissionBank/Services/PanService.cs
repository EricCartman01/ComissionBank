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
                        //_clientService.Insert(client);

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
                        //_advisorService.Insert(advisor);

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
                    //Insert(newPan);

                    /*string strPanValue = fields[5].Trim().Replace("R$", " ");
                    string strPanValue1 = strPanValue.Trim().Replace("-", " ");
                    double panValue = double.Parse(strPanValue1,CultureInfo.CreateSpecificCulture("pt-BR"));
                    
                    string strPanLiquidValue = fields[6].Trim().Replace("R$", " ");
                    string strPanLiquidValue1 = strPanLiquidValue.Trim().Replace("-", " ");
                    double panLiquidValue = double.Parse(strPanLiquidValue1,CultureInfo.CreateSpecificCulture("pt-BR"));

                    string strNetAdvisorValue = fields[7].Trim().Replace("%", " ");
                    string strNetAdvisorValue1 = strNetAdvisorValue.Trim().Replace("-", " ");
                    double netAdvisorValue = double.Parse(strNetAdvisorValue1, CultureInfo.CreateSpecificCulture("pt-BR"));

                    string strBankValue = fields[8].Trim().Replace("R$-", " ");
                    string strBankValue1 = strBankValue.Trim().Replace("-R$", " ");
                    string strBankValue2 = strBankValue1.Trim().Replace("-", " ");
                    string strBankValue3 = strBankValue2.Trim().Replace("R$", " ");

                    double result;
                    var isvalid = double.TryParse(strBankValue3, out result);
                    double bankValue = isvalid ? result : 0;
                    */
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
