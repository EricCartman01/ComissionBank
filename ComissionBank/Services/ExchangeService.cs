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
using System.Text.RegularExpressions;

namespace ComissionBank.Services
{ 
    public class ExchangeService
    {
        private readonly ComissionBankContext _context;

        public ExchangeService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }
        public double GetTotal()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            month = 12;
            year = 2018;

            double totalExchange = _context.Exchange.Where(x => x.Date.Month == month).Where(x => x.Date.Year == year).Sum(x => x.BankValue);

            return totalExchange;
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

                    /*
                    string data1 = fields[0].Replace(" ",String.Empty);
                    string data2 = Regex.Replace(data1, @"\s", "");
                    string data3 = String.Concat(data2.Where(x => !Char.IsWhiteSpace(x)));
                    */

                    if (fields[0] == "")
                    {
                        break;
                    }

                    DateTime date   = DateTime.Parse(fields[0],CultureInfo.CreateSpecificCulture("pt-BR"),DateTimeStyles.None);
                    string clientCpf = fields[1];
                    string clientName = fields[2];
                    string advisorInitials = fields[3].Trim();

                    int clientId = _context.Client.Where(x => x.Name == clientName).Where(x => x.AdvisorInitials == advisorInitials).Select(x => x.Id).FirstOrDefault();
                    if (clientId == 0)
                    {
                        Client client = new Client(clientName, "code0", advisorInitials, clientCpf);

                        _context.Client.Add(client);
                        try
                        {
                            _context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            throw new Exception(e.Message);
                        }
                        clientId = _context.Client.Where(x => x.Name == clientName).Where(x => x.AdvisorInitials == advisorInitials).Select(x => x.Id).FirstOrDefault();
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

                    string houseExchange = fields[4].Trim();
                    string order = fields[5];
                    string currency = fields[6];

                    double grossValue = GetDouble(fields[7]);
                    double value = GetDouble(fields[8]);
                    double cotation = GetDouble(fields[9]);
                    string comissionType = fields[10];
                    double spread = GetDouble(fields[11]);
                    double comissionValue = GetDouble(fields[12]);
                    double liquidValue = GetDouble(fields[13]);
                    double netAdvisorValue = GetDouble(fields[14]);
                    double bankValue = GetDouble(fields[15]);
                    double operatorValue = GetDouble(fields[16]);
                    double advisorValue = GetDouble(fields[17]);

                    int month   = int.Parse(fields[18].Trim());
                    int year    = int.Parse(fields[19].Trim());

                    Exchange exchange = new Exchange(date, clientId, clientCpf, clientName, advisorInitials, advisorId, houseExchange, order, currency, grossValue, value, cotation, comissionType, spread, comissionValue, liquidValue, netAdvisorValue, bankValue, operatorValue, advisorValue, month, year);
                    exchanges.Add(exchange);
                    Insert(exchange);

                }
                
            }

            return exchanges;
            
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
