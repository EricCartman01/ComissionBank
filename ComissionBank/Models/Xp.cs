using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace ComissionBank.Models
{
    public class Xp
    {
        public int Id { get; set; }
        public DateTime Register { get; set; } = DateTime.Now;
        public DateTime Date { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public string AdvisorInitials { get; set; }
        public Advisor Advisor { get; set; }
        public int AdvisorId { get; set; }
        public string ProductName { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string Market { get; set; }
        public double GrossIncomeValue { get; set; }
        public double GrossLiquidValue { get; set; }
        public double NetProductValue { get; set; }
        public double TransferValue { get; set; }
        public double LiquidValue { get; set; }
        public double NetAdvisorValue { get; set; }
        public double BankValue { get; set; }
        public double AdvisorValue { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Xp()
        {

        }

        public Xp(DateTime date, string clientCode, string clientName, int clientId, string advisorInitials, int advisorId, string productName, int productId, string market, double grossIncomeValue, double grossLiquidValue, double netProductValue, double transferValue, double liquidValue, double netAdvisorValue, double bankValue, double advisorValue, int month, int year)
        {
            Date = date;
            ClientCode = clientCode;
            ClientName = clientName;
            ClientId = clientId;
            AdvisorInitials = advisorInitials;
            AdvisorId = advisorId;
            ProductName = productName;
            ProductId = productId;
            Market = market;
            GrossIncomeValue = grossIncomeValue;
            GrossLiquidValue = grossLiquidValue;
            NetProductValue = netProductValue;
            TransferValue = transferValue;
            LiquidValue = liquidValue;
            NetAdvisorValue = netAdvisorValue;
            BankValue = bankValue;
            AdvisorValue = advisorValue;
            Month = month;
            Year = year;
        }

        public string DateFormated { get { return Date.ToShortDateString(); }}
        public string GrossIncomeValueFormated { get { return GrossIncomeValue.ToString("C2", CultureInfo.CurrentCulture); } }
        public string GrossLiquidValueFormated { get { return GrossLiquidValue.ToString("C2", CultureInfo.CurrentCulture); } }
        public string NetProductValueFormated { get { return NetProductValue + "%"; } }
        public string TransferValueFormated { get { return TransferValue.ToString("C2", CultureInfo.CurrentCulture); } }
        public string LiquidValueFormated { get { return LiquidValue.ToString("C2", CultureInfo.CurrentCulture); } }
        public string NetAdvisorValueFormated { get { return NetAdvisorValue + "%"; } }
        public string BankValueFormated { get { return BankValue.ToString("C2", CultureInfo.CurrentCulture); } }
        public string AdvisorValueFormated { get { return AdvisorValue.ToString("C2", CultureInfo.CurrentCulture); } }
    }
}
