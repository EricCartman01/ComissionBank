using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;
using System.IO;

namespace ComissionBank.Services
{
    public class ClientService
    {
        private readonly ComissionBankContext _context;

        public ClientService(ComissionBankContext context)
        {
            _context = context;
        }

        public Client FindByName(string name)
        {
            return _context.Client.FirstOrDefault(x => x.Name == name);
        }

        public Client FindById(int Id)
        {
            return _context.Client.FirstOrDefault(x => x.Id == Id);
        }

        public string GetIdByCpf(Comission comission)
        {
            var _Cpf = _context.Client.Where(x => x.Cpf == comission.Client.Cpf).Select(x => x.Cpf).FirstOrDefault();
            return _Cpf;
        }

        public void Insert(Client client)
        {
            _context.Client.Add(client);
            try
            {
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
