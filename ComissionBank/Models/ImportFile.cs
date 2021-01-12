using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models;
using System.IO;
using System.Globalization;

namespace ComissionBank.Models
{
    public class ImportFile
    {
        public List<Pan> ImportExchange()
        {
            string path = @"d:\temp\pan.csv";
            List<Pan> pans = new List<Pan>();

            using (StreamReader streamReader = File.OpenText(path))
            {
                while (!streamReader.EndOfStream)
                {
                    string[] fields = streamReader.ReadLine().Split(';');
                    string broker = fields[0];
                    string clientCode = fields[1];
                    string clientName = fields[2];
                    //pans.Add(new Pan(broker, clientCode, clientName));
                }
            }

            return pans;
        }
    }
}
