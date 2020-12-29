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

        public List<Client> FindAll()
        {
            return _context.Client.ToList();
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

        public void Remove(int id)
        {
            var obj = _context.Client.Find(id);
            _context.Client.Remove(obj);
            
            try
            {
                _context.SaveChanges();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public List<Client> Import()
        {
            string path = @"c:\temp\XP.csv";
            List<Client> clientList = new List<Client>();

            using (StreamReader streamReader = File.OpenText(path))
            {
                while (!streamReader.EndOfStream)
                {
                    string[] fields = streamReader.ReadLine().Split(',');
                    string clientCode = fields[2];
                    string name = fields[3];
                    string advisorInitials = fields[4];
                    
                    clientList.Add(new Client(name, clientCode, advisorInitials));

                    if(!_context.Client.Any(x => x.Name == name))
                    {
                        Client client = new Client(name, clientCode, advisorInitials);
                        Insert(client);
                    }
                }
            }

            return clientList;
        }
    }
}

