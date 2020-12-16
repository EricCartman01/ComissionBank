using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models
{
    public class Pan
    {
        public string Broker { get; set; }
        public DateTime Date { get; set; }
        public string ClientCode { get; set; }
        public string ClientName { get; set; }
        public string AdvisorName { get; set; }
        public double PanValue { get; set; }
        public double PanLiquidValue { get; set; }
        public double Percentual { get; set; }
        public double AdvisorValue { get; set; }

        public Pan()
        {

        }

        public Pan(string broker, string clientCode, string clientName)
        {
            Broker = broker;
            ClientCode = clientCode;
            ClientName = clientName;
        }
    }
}
