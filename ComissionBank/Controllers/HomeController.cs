using ComissionBank.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Services;

namespace ComissionBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly PanService _panService;
        private readonly ProtectService _protectService;
        private readonly ExchangeService _exchangeService;
        private readonly XpService _xpService;

        public HomeController(PanService panService, ProtectService protectService, ExchangeService exchangeService, XpService xpService)
        {
            _panService = panService;
            _protectService = protectService;
            _exchangeService = exchangeService;
            _xpService = xpService;
        }
        public IActionResult Index()
        {
            //_panService.GetTotal(DateTime.Today);
            double totalPan = _panService.GetTotal();
            double totalProtect = _protectService.GetTotal();
            double totalXp = _xpService.GetTotal();
            double totalCambio = _exchangeService.GetTotal();

            ViewBag.totalPan = totalPan;
            ViewBag.totalProtect = totalProtect;
            ViewBag.totalXp = totalXp;
            ViewBag.totalCambio = totalCambio;

            return View(ViewBag);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
