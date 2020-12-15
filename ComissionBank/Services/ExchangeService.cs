using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;
using Microsoft.EntityFrameworkCore;
using ComissionBank.Services.Exceptions;

namespace ComissionBank.Services
{ 
    public class ExchangeService
    {
        private readonly ComissionBankContext _context;

        public ExchangeService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }

        public void Insert(Exchange exchange)
        {
            _context.Exchange.Add(exchange);
            _context.SaveChanges(); 
        }

        public void Remove(int id)
        {
            var obj = _context.Exchange.Find(id);
            _context.Exchange.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Exchange exchange)
        {
            if(!_context.Exchange.Any(x => x.Id == exchange.Id))
            {
                throw new Exception("Câmbio não encontrado");
            }

            try
            {
                _context.Update(exchange);
                _context.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public List<Exchange> FindAll()
        {
            return _context.Exchange.ToList(); 
        }

        public Exchange FindById(int id)
        {
            return _context.Exchange.FirstOrDefault(x => x.Id == id);
        }

    }
}
