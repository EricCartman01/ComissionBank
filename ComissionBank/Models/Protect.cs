using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models
{
    public class Protect
    {
        public int Id { get; set; }
        public DateTime Record { get; set; } = DateTime.Now;
        public DateTime Date { get; set; }
        public string ClientName { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }
        public House House { get; set; }
        public int HouseId { get; set; }
        public Advisor Advisor { get; set; }
        public int AdvisorId { get; set; }
        public string AdvisorInitials { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public double Value { get; set; }
        public double LiquidValue { get; set; }
        public double NetValue { get; set; }
        public double AdvisorValue { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
