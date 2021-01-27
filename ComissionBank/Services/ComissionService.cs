using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;

namespace ComissionBank.Services
{
    public class ComissionService
    {
        private readonly ComissionBankContext _context;

        public ComissionService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }

        public void Insert(Comission comission)
        {
            if (!_context.Client.Any(x => x.Cpf == comission.Client.Cpf))
            {
                //Insert(comission.Client);
            }

            //var _cpf = _clientService.FindByCpf(comission.Client.Cpf);
            comission.Client.Id = _context.Client.Where(x => x.Cpf == comission.Client.Cpf).Select(x => x.Id).FirstOrDefault();
            _context.Add(comission);
            _context.SaveChanges();
        }

        public void Remove(Comission comission)
        {
            _context.Remove(comission);
            _context.SaveChanges();
        }

        public List<Comission> FindAll()
        {
            return _context.Comission.ToList();
        }

    }
}
