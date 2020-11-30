using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using Microsoft.EntityFrameworkCore;

namespace ComissionBank.Models.Services
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
            catch (DbUpdateConcurrencyException)
            {
                //throw new DbUpdateConcurrencyException(e.Message);
            }
        }

        public List<Advisor> FindAll()
        {
            return _context.Advisor.ToList();
        }

        public Advisor FindById(int id)
        {
            return _context.Advisor.FirstOrDefault(x => x.Id == id);
        }

        public Advisor FindByInitial(string initials)
        {
            return _context.Advisor.FirstOrDefault(x => x.Initials == initials);
        }

        public void LoadXPS()
        {
            return;
        }

        public void LoadXP()
        {

        }
    }
}
