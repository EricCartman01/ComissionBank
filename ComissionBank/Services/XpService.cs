using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Models;
using ComissionBank.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Globalization;

namespace ComissionBank.Services
{
    public class XpService
    {
        private readonly ComissionBankContext _context;

        public XpService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }

        public List<Xp> FindAll()
        {
            return _context.Xp.ToList();
        }

        public void Insert(Xp xp)
        {
            _context.Xp.Add(xp);
            _context.SaveChanges();
        }

        public void Remove(Xp xp)
        {
            _context.Remove(xp);
            _context.SaveChanges();
        }

        public Xp FindById(int id)
        {
            return _context.Xp.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Xp xp)
        {
            if(! _context.Xp.Any(x => x.Id == xp.Id))
            {
                throw new Exception("Comissão XP não encontrada!");
            }

            try
            {
                _context.Update(xp);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public List<Xp> Import()
        {
            string path = @"c:\temp\xp.csv";
            List<Xp> xpList  = new List<Xp>();

            using (StreamReader streamReader = File.OpenText(path))
            {
                while (!streamReader.EndOfStream)
                {
                    string[] fields = streamReader.ReadLine().Split(',');
                    DateTime date = DateTime.Parse(fields[0], CultureInfo.CreateSpecificCulture("pt-BR"), DateTimeStyles.None);
                    string clientCode = fields[1];
                    xpList.Add(new Xp(date, clientCode));


                }
            }

            return xpList;
        }
    }
}
