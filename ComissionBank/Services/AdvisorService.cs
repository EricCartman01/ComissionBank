using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComissionBank.Data;
using ComissionBank.Models;
using ComissionBank.Services.Exceptions;
using System.Security.Cryptography;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ComissionBank.Services
{
    public class AdvisorService
    {
        private readonly ComissionBankContext _context;

        public AdvisorService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }

        public async Task Insert(Advisor advisor)
        {
            _context.Add(advisor);
            await _context.SaveChangesAsync();

        }

        public void Delete(int id)
        {
            var obj = _context.Advisor.Find(id);
            _context.Advisor.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Advisor advisor)
        {
            if (!_context.Advisor.Any(x => x.Id == advisor.Id))
            {
                throw new Exception("Assessor não Encontrado!");
            }

            try
            {
                _context.Update(advisor);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public async Task<List<Advisor>> FindAll()
        {
            return await _context.Advisor.ToListAsync();
        }

        public Advisor FindByName(string name)
        {
            return _context.Advisor.FirstOrDefault(x => x.Name == name);
        }

        public Advisor FindById(int id)
        {
            return _context.Advisor.FirstOrDefault(x => x.Id == id);
        }

        public Advisor FindByInitial(string initials)
        {
            return _context.Advisor.FirstOrDefault(x => x.Initials == initials);
        }

        public int GetIdByInitials(string initials)
        {
            return _context.Advisor.Where(x => x.Initials == initials).Select(x => x.Id).FirstOrDefault();
        }

        public List<Advisor> ImportBasic()
        {
            string path = @"c:\temp\ASSESSORES_byLeo.csv";
            List<Advisor> advisorsList = new List<Advisor>();

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

                    string name     = fields[0];
                    string initials = fields[1];
                    advisorsList.Add(new Advisor(name, initials));

                    if (! _context.Advisor.Any(x => x.Initials == initials))
                    {
                        Advisor advisor = new Advisor(name, initials);
                        Insert(advisor);
                    }
                        
                }
            }

            return advisorsList;
        }

        public List<Advisor> Import()
        {
            string path = @"c:\temp\ASSESSORES_leo_jan_2021.csv";
            List<Advisor> advisorsList = new List<Advisor>();

            using (StreamReader streamReader = File.OpenText(path))
            {
                streamReader.ReadLine();

                while (!streamReader.EndOfStream)
                {
                    char[] delimiterChars   = { ';' };
                    string[] fields         = streamReader.ReadLine().Split(delimiterChars);

                    if (string.IsNullOrEmpty(fields[0]) == true)
                    {
                        break;
                    }

                    string name = fields[0];
                    string initials = fields[1].Trim();
                    string matrixName = fields[2].Trim();
                    string email = fields[3];
                    string password = GetRandomAlphanumericString(8);

                    double xpc = GetDoublePercent(fields[4]);
                    double cmbc = GetDoublePercent(fields[5]);
                    double protc = GetDoublePercent(fields[6]);
                    double itaz = GetDoublePercent(fields[7]);
                    double jurc = GetDoublePercent(fields[8]);
                    double pan = GetDoublePercent(fields[9]);
                    double xpTable = GetDoublePercent(fields[9]);

                    bool isHeadQuarter = false;
                    if (fields[11] == "F")
                    {
                        isHeadQuarter = true;
                    }

                    Advisor advisor = new Advisor(name, initials, matrixName, email, password, xpc, cmbc, protc, itaz, jurc, pan, xpTable, isHeadQuarter);
                    advisorsList.Add(advisor);

                    if (!_context.Advisor.Any(x => x.Initials == initials))
                    {
                        Insert(advisor);
                    }

                    // ******** novos valores NOVA planilha Raquel ************
                    //string strXpc = fields[4].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ").Replace("#REF!", " ").Replace("%"," ");
                    //string strXpc2 = Regex.Replace(strXpc, @"[^\d]", "");
                    //double xpc = double.Parse("100", CultureInfo.CreateSpecificCulture("pt-BR"));

                    //var apenasDigitos = new Regex(@"[^\d]");
                    //return apenasDigitos.Replace(str, "");

                    //var numbers = new Regex(@"[^\d]");
                    //double resultDoubleConversion;

                    //string strXpc = numbers.Replace(fields[4], "");
                    //var isValidComission = double.TryParse(strXpc, out resultDoubleConversion);
                    //double xpc = (isValidComission ? resultDoubleConversion : 0)/100;

                    //string strCmbc = fields[5].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ").Replace("#REF!", " ").Replace("%", " ");
                    //double cmbc = double.Parse("10", CultureInfo.CreateSpecificCulture("pt-BR"));

                    //string strProtc = fields[6].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ").Replace("#REF!", " ").Replace("%", " ");
                    //double protc = double.Parse("11", CultureInfo.CreateSpecificCulture("pt-BR"));

                    //string strItaz = fields[7].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ").Replace("#REF!", " ").Replace("%", " ");
                    //double itaz = double.Parse("12", CultureInfo.CreateSpecificCulture("pt-BR"));

                    //string strJurc = fields[8].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ").Replace("#REF!", " ").Replace("%", " ");
                    //double jurc = double.Parse("13", CultureInfo.CreateSpecificCulture("pt-BR"));

                    //string strPan = fields[9].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ").Replace("#REF!", " ").Replace("%", " ");
                    //double pan = double.Parse("14", CultureInfo.CreateSpecificCulture("pt-BR"));

                    //string strXpTable = fields[10].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ").Replace("#REF!", " ").Replace("%", " ");
                    //double xpTable = double.Parse(strXpTable, CultureInfo.CreateSpecificCulture("pt-BR"));

                    //bool isHeadQuarter = bool.Parse(strIsHeadQuarter);

                    //Mudancas Nova Planilha Assessores Raquel
                    //bool employee = bool.Parse(fields[4].Trim().Replace("X", "true"));
                    //string strNetCertification  = fields[5].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ").Replace("#REF!", "");
                    //double netCertification     = double.Parse(strNetCertification, CultureInfo.CreateSpecificCulture("pt-BR"));

                    //string strNet = fields[6].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ").Replace("#REF!","");
                    //double net = double.Parse(strNet, CultureInfo.CreateSpecificCulture("pt-BR"));

                    //string strNetBirthday = fields[7].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ").Replace("#REF!", "");
                    //double netBirthday = double.Parse(strNetBirthday, CultureInfo.CreateSpecificCulture("pt-BR"));

                    //string strNetTotal = fields[8].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ").Replace("#REF!", "");
                    //double netTotal = double.Parse(strNetTotal, CultureInfo.CreateSpecificCulture("pt-BR"));

                }
            }

            return advisorsList;
        }

        public static string GetRandomString(int length, IEnumerable<char> characterSet)
        {
            if (length < 0)
                throw new ArgumentException("length must not be negative", "length");
            if (length > int.MaxValue / 8) // 250 million
                throw new ArgumentException("length is too big", "length");
            if (characterSet == null)
                throw new ArgumentNullException("characterSet");
            var characterArray = characterSet.Distinct().ToArray();
            if (characterArray.Length == 0)
                throw new ArgumentException("characterSet must not be empty", "characterSet");

            var bytes = new byte[length * 8];
            new RNGCryptoServiceProvider().GetBytes(bytes);
            var result = new char[length];
            for (int i = 0; i < length; i++)
            {
                ulong value = BitConverter.ToUInt64(bytes, i * 8);
                result[i] = characterArray[value % (uint)characterArray.Length];
            }
            return new string(result);
        }
        public string GetRandomAlphanumericString(int length)
        {
            const string alphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" + "abcdefghijklmnopqrstuvwxyz" + "0123456789";
            return GetRandomString(length, alphanumericCharacters);
        }

        public static double GetDoublePercent(string strDouble)
        {
            var numbers = new Regex(@"[^\d]");
            double resultDoubleConversion;

            string strResult = numbers.Replace(strDouble, "");
            var isValidComission = double.TryParse(strResult, out resultDoubleConversion);
            
            double doubleResult = (isValidComission ? resultDoubleConversion : 0) / 100;
            
            return doubleResult;
        }

    }
}
