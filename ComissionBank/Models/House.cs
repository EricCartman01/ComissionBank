using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Abbreviaton { get; set; }

        public House()
        {

        }

        public House(int id, string name, string details, string abbreviaton)
        {
            Id = id;
            Name = name;
            Details = details;
            Abbreviaton = abbreviaton;
        }
    }

   
}
