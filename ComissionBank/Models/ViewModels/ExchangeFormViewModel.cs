using System.Collections.Generic;

namespace ComissionBank.Models.ViewModels
{
    public class ExchangeFormViewModel
    {
        public Exchange Exchange { get; set; }
        public ICollection<Advisor> Advisors { get; set; }
    }
}
