using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
using ComissionBank.Models.Enums;

namespace ComissionBank.Models
{
    public class Advisor
    {
        public int Id { get; set; }
        public DateTime Record { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Cpf { get; set; }
        public DateTime Birthday { get; set; }
        public string Telephone { get; set; }
        public string XpCode { get; set; }
        public Bank Bank { get; set; }
        public string BankAgency { get; set; }
        public string BankAccount { get; set; }
        public DateTime Initial { get; set; }
        public bool Employee { get; set; }
        public string Matrix { get; set; }
        public string Cfp { get; set; }
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
        public bool IsActive { get; set; }
        public ICollection<Comission> Comissions { get; set; } = new List<Comission>();

        public Advisor()
        {

        }

        public Advisor(string name, string initials)
        {
            Name = name;
            Initials = initials;
        }

        public Advisor(string name, string initials, string email, string password)
        {
            Name = name;
            Initials = initials;
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

        public Advisor(string name, string initials, string cpf)
        {
            Name = name;
            Initials = initials;
            Cpf = cpf;
        }

        public Advisor(string name,string initials, string xpCode, string email, bool employee, double netCertification,double net, double netBirthday, double netTotal, double xpc, double cmbc, double protc, double itaz, double jurc, double pan)
        {
            Name = name;
            Initials = initials;
            XpCode = xpCode;
            Email = email;
            Employee = employee;
            NetCertification = netCertification;
            Net = net;
            NetBirthday = netBirthday;
            NetTotal = netTotal;
            XPC = xpc;
            CMBC = cmbc;
            PROTC = protc;
            ITAZ = itaz;
            JURC = jurc;
            PAN = pan;
        }

    }
}
