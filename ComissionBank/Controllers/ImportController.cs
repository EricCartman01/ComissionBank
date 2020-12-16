using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models;

namespace ComissionBank.Controllers
{
    public class ImportController : Controller
    {
        public IActionResult Index()
        {
            ImportFile importFile = new ImportFile();
            var teste = importFile.ImportExchange();
            return View(teste);
        }
    }
}
