using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;

namespace ComissionBank.Services
{
    public class HouseService
    {
        private readonly ComissionBankContext _context;
        public HouseService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }

        public int GetIdByName(string name)
        {
            return _context.House.Where(x => x.Name == name).Select(x => x.Id).FirstOrDefault();
        }
    }
}
