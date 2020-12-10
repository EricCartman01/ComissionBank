using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models
{
    public class Protect
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Client MyProperty { get; set; }
        public int House { get; set; }
        public Advisor Advisor { get; set; }
    }
}
