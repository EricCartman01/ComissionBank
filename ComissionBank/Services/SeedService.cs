using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;

namespace ComissionBank.Services
{
    public class SeedService
    {
        private ComissionBankContext _context;

        public SeedService(ComissionBankContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Advisor.Any())
            {
                return;
            }

        }
    }
}
