using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models
{
    public class Xp
    {
        public DateTime Register { get; set; } = DateTime.Now;
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
}
