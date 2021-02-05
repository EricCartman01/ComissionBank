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
            var brokers = _brokerService.Top(50);
            return View(brokers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Broker broker)
        {
            _brokerService.Insert(broker);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _brokerService.FindById(id.Value);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
