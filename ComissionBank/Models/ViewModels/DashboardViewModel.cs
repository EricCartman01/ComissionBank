using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComissionBank.Models.ViewModels
{
    public class DashboardViewModel
    {
        public Advisor Advisor { get; set; }
        public ICollection<Pan> Pans { get; set; }
    }
}
