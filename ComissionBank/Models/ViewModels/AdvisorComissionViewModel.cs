using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Services;

namespace ComissionBank.Models.ViewModels
{
    public class AdvisorComissionViewModel
    {
        public Advisor Advisor { get; set; }
        public ICollection<Pan> Pans { get; set; }
        public ICollection<Protect> Protects { get; set; }
        public ICollection<Exchange> Exchanges { get; set; }
        public ICollection<Xp> Xps { get; set; }

    }
}
