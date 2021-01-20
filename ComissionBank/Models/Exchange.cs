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
        public string Name { get; set; }
        public string AdvisorInitials { get; set; }
        public Advisor Advisor { get; set; }
        public int AdvisorId { get; set; }

        public string HouseName { get; set; }
        public House House { get; set; }
        public int HouseId { get; set; }
        public string Order { get; set; }
        public string Currency { get; set; }
        public double GrossValue { get; set; }
        public double Value { get; set; }
        public double Cotation { get; set; }
        public string ComissionType { get; set; }
        public double Spread { get; set; }
        public Double Comission { get; set; }
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

        public Exchange(int id, DateTime date, Advisor advisor, string order, string currency, double grossValue, double value, double cotation, string comissionType, double spread, double comission, double netAdvisorValue)
        {
            Id = id;
            Date = date;
            Advisor = advisor;
            Order = order;
            Currency = currency;
            GrossValue = grossValue;
            Value = value;
            Cotation = cotation;
            ComissionType = comissionType;
            Spread = spread;
            Comission = comission;
            NetAdvisorValue = netAdvisorValue;
        }

        public Exchange(int id, DateTime date, Client client, int clientId, string cpf, string name, Advisor advisor, int advisorId, string houseName, string order, string currency, double grossValue, double value, double cotation, string comissionType, double spread, double comission, double liquidValue, double netAdvisorValue, double advisorValue, int month, int year)
        {
            Id = id;
            Record = DateTime.Now;
            Date = date;
            Client = client;
            ClientId = clientId;
            Cpf = cpf;
            Name = name;
            Advisor = advisor;
            AdvisorId = advisorId;
            HouseName = houseName;
            Order = order;
            Currency = currency;
            GrossValue = grossValue;
            Value = value;
            Cotation = cotation;
            ComissionType = comissionType;
            Spread = spread;
            Comission = comission;
            LiquidValue = liquidValue;
            NetAdvisorValue = netAdvisorValue;
            AdvisorValue = advisorValue;
            Month = month;
            Year = year;
        }

        public Exchange(DateTime date)
        {
            Date = date;

        }

        public Exchange(DateTime date, string cpf, string name, string advisorInitials, string houseName, string order, string currency, double grossValue, double value, double cotation, double spread) 
        {
            Date = date;
            Cpf = cpf;
            Name = name;
            AdvisorInitials = advisorInitials;
            HouseName = houseName;
            Order = order;
            Currency = currency;
            GrossValue = grossValue;
            Value = value;
            Cotation = cotation;
            Spread = spread;
        }

        public Exchange(DateTime date, string cpf, string name, string advisorInitials, string houseName, int houseId, string order, string currency, double grossValue, double value, double cotation, string comissionType, double spread, double comission, double liquidValue, double netAdvisorValue, double bankValue, double operatorValue, double advisorValue, int month, int year) : this(date)
        {
            Cpf = cpf;
            Name = name;
            AdvisorInitials = advisorInitials;
            HouseName = houseName;
            HouseId = houseId;
            Order = order;
            Currency = currency;
            GrossValue = grossValue;
            Value = value;
            Cotation = cotation;
            ComissionType = comissionType;
            Spread = spread;
            Comission = comission;
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
