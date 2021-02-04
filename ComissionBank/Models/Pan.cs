using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace ComissionBank.Models
{
    public class Pan
    {
        public int Id { get; set; }
        public DateTime Record { get; set; } = DateTime.Now;
        public DateTime Date { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Advisor Advisor { get; set; }
        public int AdvisorId { get; set; }
        public string AdvisorInitials { get; set; }
        public double PanValue { get; set; }
        public double PanLiquidValue { get; set; }
        public double NetAdvisorValue { get; set; }
        public double BankValue { get; set; }
        public double AdvisorValue { get; set; }

        public Pan()
        {

        }

        public Pan(DateTime date, string clientCode, string clientName, string advisorInitials, double panvalue, double panLiquidValue, double netAdvisorValue, double bankValue)
        {
            Date = date;
            ClientCode = clientCode;
            ClientName = clientName;
            AdvisorInitials = advisorInitials;
            PanValue = panvalue;
            PanLiquidValue = panLiquidValue;
            NetAdvisorValue = netAdvisorValue;
            BankValue = bankValue;

        }

        public Pan(DateTime date, string clientCode, string clientName, int clientId, int advisorId, string advisorInitials, double panvalue, double panLiquidValue, double netAdvisorValue, double bankValue)
        {
            Date = date;
            ClientCode = clientCode;
            ClientName = clientName;
            ClientId = clientId;
            AdvisorId = advisorId;
            AdvisorInitials = advisorInitials;
            PanValue = panvalue;
            PanLiquidValue = panLiquidValue;
            NetAdvisorValue = netAdvisorValue;
            BankValue = bankValue;

        }

        public string DateFormated { get {return Date.ToShortDateString();} }
        public string PanValueFormated { get { return PanValue.ToString("C2", CultureInfo.CurrentCulture); } }
        public string PanLiquidValueFormated { get { return PanLiquidValue.ToString("C2", CultureInfo.CurrentCulture); } }
        public string NetAdvisorValueFormated { get { return NetAdvisorValue + "%"; } }
        public string BankValueFormated { get { return BankValue.ToString("C2", CultureInfo.CurrentCulture); } }
        public string AdvisorValueFormated { get { return AdvisorValue.ToString("C2", CultureInfo.CurrentCulture); } }
    }
}
