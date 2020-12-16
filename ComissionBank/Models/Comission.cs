using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models.Enums;

namespace ComissionBank.Models
{
    public class Comission
    {
        public int Id { get; set; }
        public Broker Broker { get; set; }
        public DateTime Date { get; set; }
        public Client Client { get; set; }
        public House House { get; set; }
        public int HouseId { get; set; }

        public Advisor Advisor { get; set; }
        public int AdvisorId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public string ClientCode { get; set; }

        public Order Order { get; set; }
        public Yield Yield { get; set; }


        public double Value { get; set; }
        public double LiquidValue { get; set; }
        public double PercentualAdvisor { get; set; }
        public double AdvisorValue { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Comission()
        {

        }

        public Comission(DateTime date)
        {
            Date = date;
        }
    }
}
