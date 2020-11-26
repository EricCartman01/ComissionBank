using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ComissionBank.Models;

namespace ComissionBank.Data
{
    public class ComissionBankContext : DbContext
    {
        public ComissionBankContext (DbContextOptions<ComissionBankContext> options)
            : base(options)
        {
        }

        public DbSet<ComissionBank.Models.Teste> Teste { get; set; }
    }
}
