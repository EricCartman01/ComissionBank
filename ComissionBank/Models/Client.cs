using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }

        public Client()
        {

        }

        public Client(int id, string name, string email, string cpf, string telefone)
        {
            Id = id;
            Name = name;
            Email = email;
            Cpf = cpf;
            Telefone = telefone;
        }

        
    }
}
