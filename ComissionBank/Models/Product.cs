using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models.Enums;

namespace ComissionBank.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Market Market { get; set; }
        public string Details { get; set; }

        public Product()
        {

        }

       
    }
}
