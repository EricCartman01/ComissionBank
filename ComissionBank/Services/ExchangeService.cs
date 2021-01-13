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

                    //------------ TESTES -----------------------------------
                    /*
                    string data1 = fields[0].Replace(" ",String.Empty);
                    string data2 = Regex.Replace(data1, @"\s", "");
                    string data3 = String.Concat(data2.Where(x => !Char.IsWhiteSpace(x)));
                    string test4 = data3.Substring(0, 2) + data3.Substring(3, 2) + data3.Substring(6, 2);
                    DateTime data5 = DateTime.Parse(teste4, CultureInfo.CreateSpecificCulture("pt-BR"));

                    string merda = "09/09/09";
                    int dia1 = int.Parse(merda.Substring(0, 2));
                    int mes1 = int.Parse(merda.Substring(3, 2));
                    int ano1 = int.Parse(merda.Substring(6, 2));
                    DateTime dataCompleta = new DateTime(ano1, mes1, dia1);
                    string data1 = Convert.ToString(fields[0], CultureInfo.InvariantCulture);
                    */

                    //------------ FIM TESTES -----------------------------------

                    if (fields[0] == "")
                    {
                        break;
                    }

                    DateTime data   = DateTime.Parse(fields[0],CultureInfo.CreateSpecificCulture("pt-BR"),DateTimeStyles.None);
                    string cpf      = fields[1];
                    string name     = fields[2];
                    string advisorInitials = fields[3].Trim();

                    if (!_context.Client.Any(x => x.Name == name))
                    {
                        Client newClient = new Client(name, cpf, advisorInitials);
                        //_clientService.Insert(newClient);
                    }

                    //int clientId = _clientService.GetIdByName(name);

                    if (! _context.Advisor.Any(x => x.Initials == advisorInitials)){ 
                        Advisor newAdvisor = new Advisor(name, advisorInitials, cpf);
                        //_advisorService.Insert(newAdvisor);
                    }

                    //int advisorId = _advisorService.GetIdByInitials(advisorInitials);

                    string house    = fields[4];
                    string order    = fields[5];
                    string currency = fields[6];

                    string strGrossValue    = fields[7].Trim().Replace('$',' ');
                    double grossValue       = double.Parse(strGrossValue, CultureInfo.CreateSpecificCulture("pt-BR"));
                    
                    string strValue     = fields[8].Trim().Replace("R$", " ");
                    double value        = double.Parse(strValue);
                    
                    string strCotation  = fields[9].Trim().Replace("R$", " ");
                    double cotation     = double.Parse(strCotation, CultureInfo.CreateSpecificCulture("pt-BR"));
                    
                    string comissionType = fields[10];
                    
                    string strSpread    = fields[11].Trim().Replace(" ", " ");
                    double spread       = double.Parse(strSpread);
                    
                    string strComission     = fields[12].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ");
                    
                    double resultComission;
                    var isValidComission    = double.TryParse(strComission, out resultComission);
                    double comission        = isValidComission ? resultComission : 0;

                    string strLiquidValue   = fields[13].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ");
                    double liquidValue      = double.Parse(strLiquidValue);

                    string strNetAdvisorValue   = fields[14].Trim().Replace("%","");
                    double netAdvisorValue      = double.Parse(strNetAdvisorValue);

                    string strBankValue     = fields[15].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ");
                    double bankValue        = double.Parse(strBankValue, CultureInfo.CreateSpecificCulture("pt-BR"));

                    string strOperatorValue     = fields[16].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ");
                    double operatorValue        = double.Parse(strOperatorValue);

                    string strAdvisorValue  = fields[17].Trim().Replace("R$", " ").Replace("-R$", " ").Replace("-", " ");
                    double advisorValue     = double.Parse(strAdvisorValue);

                    int month   = int.Parse(fields[18].Trim());
                    int year    = int.Parse(fields[19].Trim());
                    
                    
                    //exchanges.Add(new Exchange(data, cpf, name, advisorInitials,house,order,currency, grossValue, value, cotation, spread));

                    exchanges.Add(new Exchange(data, cpf, name, advisorInitials, house, order, currency, grossValue, value, cotation, comissionType, spread, comission, liquidValue, netAdvisorValue, bankValue, operatorValue, advisorValue, month,year));

                    break;
                }
                
            }

            return exchanges;
            
        }

    }
}
