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
        public double ProtectValue { get; set; }
        public double ProtectLiquidValue { get; set; }
        public double NetAdvisorValue { get; set; }
        public double BankValue { get; set; }
        public double AdvisorValue { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Protect()
        {

        }

        public Protect(DateTime date, string clientName, int clientId, int houseId, int advisorId, string advisorInitials, int productId, double protectValue, double protectLiquidValue, double netAdvisorValue, double bankValue, double advisorValue, int month, int year)
        {
            Date = date;
            ClientName = clientName;
            ClientId = clientId;
            HouseId = houseId;
            AdvisorId = advisorId;
            AdvisorInitials = advisorInitials;
            ProductId = productId;
            ProtectValue = protectValue;
            ProtectLiquidValue = protectLiquidValue;
            NetAdvisorValue = netAdvisorValue;
            BankValue = bankValue;
            AdvisorValue = advisorValue;
            Month = month;
            Year = year;
        }
    }
}
