using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models
{
    public class Broker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }


        public Broker()
        {

        }

        public Broker(int id, string name, string details)
        {
            Id = id;
            Name = name;
            Details = details;
        }
    }
}
