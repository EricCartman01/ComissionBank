using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<Client>> FindAll()
        {
            return await _context.Client.ToListAsync();
        }

        public async Task<List<Client>> Top(int num)
        {
            return await _context.Client.Take(num).ToListAsync();
        }

        public int GetIdByAdvisorInitials(string advisorInitials)
        {
            return _context.Client.Where(x => x.AdvisorInitials == advisorInitials).Select(x => x.Id).FirstOrDefault();
        }

        public int GetIdByCpf(string cpf)
        {
            return _context.Client.Where(x => x.Cpf == cpf).Select(x => x.Id).FirstOrDefault();
        }

        public int GetIdByName(string name)
        {
            return _context.Client.Where(x => x.Name == name).Select(x => x.Id).FirstOrDefault();
        }

        public int GetIdClientByName(string name)
        {
            int idClient = _context.Client.Where(x => x.Name == name).Select(x => x.Id).FirstOrDefault();
            if (idClient != 0)
            {
                return idClient;
            }
            return 0;
        }
        public bool IsClient(string name)
        {
            if(! _context.Client.Any(x => x.Name == name))
            {
                return false;
            }
            return true;
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
                streamReader.ReadLine();
                int cont = 1;
                while (!streamReader.EndOfStream)
                //while(cont < 100)
                {
                    char[] delimiterChars = { ',' };
                    string[] fields = streamReader.ReadLine().Split(delimiterChars);

                    if(string.IsNullOrEmpty(fields[0]) == true)
                    {
                        break;
                    }

                    string clientCode = fields[2].Trim();
                    string clientName = fields[3].ToUpper();
                    string advisorInitials = fields[4].Trim().ToUpper();

                    clientList.Add(new Client(clientName, clientCode, advisorInitials));

                    if(!_context.Client.Any(x => x.Name == clientName))
                    {
                        Client client = new Client(clientName, clientCode, advisorInitials);
                        Insert(client);
                    }
                    cont++;
                }
            }

            return clientList;
        }
    }
}

