using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Data;
using ComissionBank.Services;
using System.IO;

namespace ComissionBank.Models
{
    public class AdvisorImport
    {
        private readonly AdvisorService _advisorService;

        public AdvisorImport(AdvisorService advisorService)
        {
            _advisorService = advisorService;
        }

        public List<Advisor> ImportFile()
        {
            string path = @"c:\temp\ASSESSORES_byLeo.csv";
            List<Advisor> advisors = new List<Advisor>();

            using (StreamReader streamReader = File.OpenText(path))
            {
                while (!streamReader.EndOfStream)
                {
                    string[] fields = streamReader.ReadLine().Split(',');
                    string name = fields[0];
                    string initials = fields[1];
                    advisors.Add(new Advisor(name, initials));
                }

            }
            return advisors;
        }

    }
}
