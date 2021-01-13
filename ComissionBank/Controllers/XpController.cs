using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models;
using ComissionBank.Services;

namespace ComissionBank.Controllers
{
    public class XpController : Controller
    {
        private readonly XpService _xpService;

        public XpController(XpService xpService)
        {
            _xpService = xpService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
