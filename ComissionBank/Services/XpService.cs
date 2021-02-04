using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;
using ComissionBank.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ComissionBank.Services
{
    public class XpService
    {
        private readonly ComissionBankContext _context;

        public XpService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }
        public double GetTotal()
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            month = 12;
            year = 2018;

            double totalXP = _context.Xp.Where(x => x.Date.Month == month).Where(x => x.Date.Year == year).Sum(x => x.BankValue);

            return totalXP;
        }
        public double GetTotalAdvisor(int id)
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            month = 12;
            year = 2018;

            double totalXP = _context.Xp.Where(x => x.AdvisorId == id).Where(x => x.Date.Month == month).Where(x => x.Date.Year == year).Sum(x => x.BankValue);

            return totalXP;
        }
        public List<Xp> FindAll()
        {
            return _context.Xp.ToList();
        }
        public List<Xp> Top(int num)
        {
            return _context.Xp.Take(num).ToList();
        }

        public void Insert(Xp xp)
        {
            _context.Xp.Add(xp);
            _context.SaveChanges();
        }

        public void Remove(Xp xp)
        {
            _context.Remove(xp);
            _context.SaveChanges();
        }

        public Xp FindById(int id)
        {
            return _context.Xp.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Xp xp)
        {
            if(! _context.Xp.Any(x => x.Id == xp.Id))
            {
                throw new Exception("Comissão XP não encontrada!");
            }

            try
            {
                _context.Update(xp);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public List<Xp> Import()
        {
            string path = @"c:\temp\xp.csv";
            List<Xp> xps  = new List<Xp>();

            using (StreamReader streamReader = File.OpenText(path))
            {
                streamReader.ReadLine();

                while (!streamReader.EndOfStream)
                {
                    string[] fields = streamReader.ReadLine().Split(',');
                    if(fields[0] == "")
                    {
                        break;
                    }
                    
                    DateTime date = DateTime.Parse(fields[1], CultureInfo.CreateSpecificCulture("pt-BR"), DateTimeStyles.None);
                    string clientCode = fields[2].Trim();
                    string clientName = fields[3].Trim();
                    string advisorInitials = fields[4].Trim();

                    int clientId = _context.Client.Where(x => x.Name == clientName).Where(x => x.AdvisorInitials == advisorInitials).Select(x => x.Id).FirstOrDefault();
                    if (clientId == 0)
                    {
                        Client client = new Client(clientName, clientCode, advisorInitials, "000 000 000 00");
                        _context.Client.Add(client);
                        try
                        {
                            _context.SaveChanges();
                        }
                        catch(Exception e)
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

                    string productName = fields[5].Trim();

                    int productId = _context.Product.Where(x => x.Name.Contains(productName)).Select(x => x.Id).FirstOrDefault();
                    if (productId == 0)
                    {
                        productId = 117;
                    }

                    string market = fields[6].Trim();
                    double grossIncomeValue = GetDouble(fields[7]);
                    double grossLiquidValue = GetDouble(fields[8]);
                    double netProductValue = GetDouble(fields[9]); ;
                    double transferValue = GetDouble(fields[10]); ;
                    double liquidValue = GetDouble(fields[11]); ;
                    double netAdvisorValue = GetDouble(fields[12]); ;
                    double bankValue = GetDouble(fields[13]); ;
                    double advisorValue = GetDouble(fields[14]); ;
                    int month = GetInt(fields[15]); ;
                    int year = GetInt(fields[16]); ;

                    Xp xp = new Xp(date, clientCode, clientName, clientId, advisorInitials, advisorId, productName, productId, market, grossIncomeValue, grossLiquidValue, netProductValue, transferValue, liquidValue, netAdvisorValue, bankValue, advisorValue, month, year);
                    xps.Add(xp);
                    Insert(xp);
                }
            }

            return xps;
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
