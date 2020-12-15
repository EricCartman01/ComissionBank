using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;

namespace ComissionBank.Services
{
    public class ProductService
    {
        private readonly ComissionBankContext _context;

        public ProductService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }

        public void Insert(Product product)
        {
            _context.Product.Add(product);
            _context.SaveChanges();
        }

        public void Remove(Product product)
        {
            _context.Product.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> FindAll()
        {
            return _context.Product.ToList();
        }

    }
}
