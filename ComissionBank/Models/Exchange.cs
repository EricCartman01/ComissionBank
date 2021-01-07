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
        public DateTime Record { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }

        public string  Cpf { get; set; }
        public string Name { get; set; }
        public string AdvisorInitials { get; set; }
        public Advisor Advisor { get; set; }
        public int AdvisorId { get; set; }

        public string House { get; set; }
        public string Order { get; set; }
        public string Currency { get; set; }
        public double GrossValue { get; set; }
        public double Value { get; set; }
        public double Cotation { get; set; }
        public string ComissionType { get; set; }
        public double Spread { get; set; }
        public Double Comission { get; set; }
        public double LiquidValue { get; set; }
        public double NetValue { get; set; }
        public double AdvisorValue { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }

        //public ICollection<Advisor> Advisors { get; set; } = new List<Advisor>();

        public Exchange()
        {
        }

        public Exchange(int id, DateTime date, Advisor advisor, string order, string currency, double grossValue, double value, double cotation, string comissionType, double spread, double comission, double netValue)
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
            NetValue = netValue;
        }

        public Exchange(int id, DateTime date, Client client, int clientId, string cpf, string name, Advisor advisor, int advisorId, string house, string order, string currency, double grossValue, double value, double cotation, string comissionType, double spread, double comission, double liquidValue, double netValue, double advisorValue, string month, string year)
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
            House = house;
            Order = order;
            Currency = currency;
            GrossValue = grossValue;
            Value = value;
            Cotation = cotation;
            ComissionType = comissionType;
            Spread = spread;
            Comission = comission;
            LiquidValue = liquidValue;
            NetValue = netValue;
            AdvisorValue = advisorValue;
            Month = month;
            Year = year;
        }

        public Exchange(DateTime date)
        {
            Date = date;

        }

        public Exchange(DateTime date, string cpf, string name, string advisorInitials, string house, string order, string currency, double grossValue, double value, double cotation, double spread) 
        {
            Date = date;
            Cpf = cpf;
            Name = name;
            AdvisorInitials = advisorInitials;
            House = house;
            Order = order;
            Currency = currency;
            GrossValue = grossValue;
            Value = value;
            Cotation = cotation;
            Spread = spread;
        }
    }
}
