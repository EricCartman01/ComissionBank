using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;

namespace ComissionBank.Services
{
    public class BrokerService
    {
        private readonly ComissionBankContext _context;

        public BrokerService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }

        public void Insert(Broker broker)
        {
            _context.Broker.Add(broker);
            _context.SaveChanges();
        }

        public void Remove(Broker broker)
        {
            _context.Broker.Remove(broker);
            _context.SaveChanges();
        }

        public List<Broker> FindAll()
        {
            return _context.Broker.ToList();
        }

        public Broker FindById(int id)
        {
            return _context.Broker.FirstOrDefault(x => x.Id == id);
        }
    }
}
