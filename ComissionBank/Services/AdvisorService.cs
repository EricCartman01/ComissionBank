using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComissionBank.Data;
using ComissionBank.Models;
using ComissionBank.Services.Exceptions;

//**** MUDEI NAMESPACE !!! *** 
namespace ComissionBank.Services
{
    public class AdvisorService
    {
        private readonly ComissionBankContext _context;

        public AdvisorService(ComissionBankContext comissionBankContext)
        {
            _context = comissionBankContext;
        }

        public void Insert(Advisor advisor)
        {
            _context.Add(advisor);
            _context.SaveChanges();

        }


        public void Remove(int id)
        {
            var obj = _context.Advisor.Find(id);
            _context.Advisor.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Advisor advisor)
        {
            if (!_context.Advisor.Any(x => x.Id == advisor.Id))
            {
                throw new Exception("Assessor não Encontrado!");
            }

            try
            {
                _context.Update(advisor);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }

        public List<Advisor> FindAll()
        {
            return _context.Advisor.ToList();
        }

        public Advisor FindByName(string name)
        {
            return _context.Advisor.FirstOrDefault(x => x.Name == name);
        }

        public Advisor FindById(int id)
        {
            return _context.Advisor.FirstOrDefault(x => x.Id == id);
        }

        public Advisor FindByInitial(string initials)
        {
            return _context.Advisor.FirstOrDefault(x => x.Initials == initials);
        }

        public int GetByInitials(string initials)
        {
            return _context.Advisor.Where(x => x.Initials == initials).Select(x => x.Id).FirstOrDefault();

        }
    }
}
