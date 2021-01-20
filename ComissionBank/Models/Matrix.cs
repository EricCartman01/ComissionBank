using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models
{
    public class Matrix
    {
        public int Id { get; set; }
        public DateTime Register { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Details { get; set; }
        public string State { get; set; }

        public Matrix()
        {

        }
    }
}
