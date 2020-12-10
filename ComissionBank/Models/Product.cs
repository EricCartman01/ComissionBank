using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public Double Price { get; set; }

        public Product()
        {

        }

        public Product(int id, string name, string details, double price)
        {
            Id = id;
            Name = name;
            Details = details;
            Price = price;
        }
    }
}
