using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;
using ComissionBank.Services.Exceptions;

namespace ComissionBank.Services
{
    public class XpService
    {
        private readonly ComissionBankContext _context;

        public XpService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }
    }
}
