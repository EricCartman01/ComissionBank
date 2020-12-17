using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Services;

namespace ComissionBank.Models
{
    public class AdvisorImport
    {
        private readonly AdvisorService _advisorService;

        public AdvisorImport(AdvisorService advisorService)
        {
            _advisorService = advisorService;
        }



    }
}
