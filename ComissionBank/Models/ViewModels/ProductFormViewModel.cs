using System.Collections.Generic;
using ComissionBank.Models.Enums;

namespace ComissionBank.Models.ViewModels
{
    public class ProductFormViewModel
    {
        public Product Product { get; set; }
        public ICollection<Market> Markets { get; set; }
    }
}


