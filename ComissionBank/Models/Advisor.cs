using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models
{
    public class Advisor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double NetCertification { get; set; }
        public double Net { get; set; }
        public double NetBirthday { get; set; }
        public double NetTotal { get; set; }
        public double XPC { get; set; }
        public double CMBC { get; set; }
        public double PROTC { get; set; }
        public double ITAZ { get; set; }
        public double JURC { get; set; }
        public double PAN { get; set; }
        //public ICollection<ComissionRecord> Comissions { get; set; } = new List<ComissionRecord>();

        public Advisor(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public Advisor(int id, string name, string initials, string email)
        {
            Id = id;
            Name = name;
            Initials = initials;
            Email = email;
        }

        public Advisor(int id, string name, string initials, string email, string password, double netCertification, double net, double netBirthday, double netTotal, double xPC, double cMBC, double pROTC, double iTAZ, double jURC, double pAN) : this(id, name, initials, email)
        {
            Password = password;
            NetCertification = netCertification;
            Net = net;
            NetBirthday = netBirthday;
            NetTotal = netTotal;
            XPC = xPC;
            CMBC = cMBC;
            PROTC = pROTC;
            ITAZ = iTAZ;
            JURC = jURC;
            PAN = pAN;
        }
    }
}
