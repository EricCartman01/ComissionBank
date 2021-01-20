using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models
{
    public class Xp
    {
        public DateTime Register { get; set; } = DateTime.Now;
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public string AdvisorInitials { get; set; }
        public string ProductName { get; set; }
        public string Market { get; set; }
        public double GrossIncomeValue { get; set; }
        public double GrossLiquidValue { get; set; }
        public double NetProductValue { get; set; }
        public double TransferValue { get; set; }
        public double LiquidValue { get; set; }
        public double NetAdvisorValue { get; set; }
        public double AdvisorValue { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Xp()
        {

        }

        public Xp(DateTime date, string clientCode)
        {
            Date = date;
            ClientCode = clientCode;
        }
    }
}
