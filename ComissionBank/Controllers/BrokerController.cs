using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models;
using ComissionBank.Services;

namespace ComissionBank.Controllers
{
    public class BrokerController : Controller
    {
        private readonly BrokerService _brokerService;

        public BrokerController(BrokerService brokerService)
        {
            _brokerService = brokerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
