using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models.Enums;

namespace ComissionBank.Models
{
    public class Exchange
    {
        public int Id { get; set; }
        public DateTime Record { get; set; } = DateTime.Now;
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }

        public string  Cpf { get; set; }
        public string ClientName { get; set; }
        public string AdvisorInitials { get; set; }
        public Advisor Advisor { get; set; }
        public int AdvisorId { get; set; }

        public string HouseExchange { get; set; }
        public string Order { get; set; }
        public string Currency { get; set; }
        public double GrossValue { get; set; }
        public double Value { get; set; }
        public double Cotation { get; set; }
        public string ComissionType { get; set; }
        public double Spread { get; set; }
        public Double ComissionValue { get; set; }
        public double LiquidValue { get; set; }
        public double NetAdvisorValue { get; set; }
        public double BankValue { get; set; }
        public double OperatorValue { get; set; }
        public double AdvisorValue { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        //public ICollection<Advisor> Advisors { get; set; } = new List<Advisor>();

        public Exchange()
        {
        }

        public Exchange(DateTime date, int clientId, string cpf, string clientName, string advisorInitials, int advisorId, string houseExchange, string order, string currency, double grossValue, double value, double cotation, string comissionType, double spread, double comissionValue, double liquidValue, double netAdvisorValue, double bankValue, double operatorValue, double advisorValue, int month, int year)
        {
            Date = date;
            ClientId = clientId;
            Cpf = cpf;
            ClientName = clientName;
            AdvisorInitials = advisorInitials;
            AdvisorId = advisorId;
            HouseExchange = houseExchange;
            Order = order;
            Currency = currency;
            GrossValue = grossValue;
            Value = value;
            Cotation = cotation;
            ComissionType = comissionType;
            Spread = spread;
            ComissionValue = comissionValue;
            LiquidValue = liquidValue;
            NetAdvisorValue = netAdvisorValue;
            BankValue = bankValue;
            OperatorValue = operatorValue;
            AdvisorValue = advisorValue;
            Month = month;
            Year = year;
        }
    }
}
