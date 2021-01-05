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
        public DateTime Date { get; set; }
        public string  Cpf { get; set; }
        public string Name { get; set; }
        public Advisor Advisor { get; set; }
        public int AdvisorId { get; set; }

        //public string House { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public Order Order { get; set; }
        public Currency Currency { get; set; }
        public double GrossValue { get; set; }
        public double Value { get; set; }
        public double Cotation { get; set; }
        public ComissionType ComissionType { get; set; }
        public double Spread { get; set; }
        public Double Comission { get; set; }
        public double NetValue { get; set; }
        //public ICollection<Advisor> Advisors { get; set; } = new List<Advisor>();
        public string GrossValueApagar { get; set; }

        public Exchange()
        {
        }

        public Exchange(int id, DateTime date, Advisor advisor, Order order, Currency currency, double grossValue, double value, double cotation, ComissionType comissionType, double spread, double comission, double netValue)
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

        public Exchange(DateTime date)
        {
            Date = date;

        }

        public Exchange(string cpf, string name, double grossValue)
        {
            Cpf = cpf;
            Name = name;
            GrossValue = grossValue;
        }
    }
}
