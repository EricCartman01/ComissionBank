using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Services;

namespace ComissionBank.Controllers
{
    public class DashboardController : Controller
    {
        private readonly PanService _panService;
        private readonly ProtectService _protectService;
        private readonly ExchangeService _exchangeService;
        private readonly XpService _xpService;

        public DashboardController(PanService panService, ProtectService protectService, ExchangeService exchangeService, XpService xpService)
        {
            _panService = panService;
            _protectService = protectService;
            _exchangeService = exchangeService;
            _xpService = xpService;
        }
        public IActionResult Index()
        {
            double totalPan = _panService.GetTotalAdvisor(10);
            double totalProtect = _protectService.GetTotalAdvisor(10);
            double totalXp = _xpService.GetTotalAdvisor(10);
            double totalCambio = _exchangeService.GetTotalAdvisor(10);

            ViewBag.totalPan = totalPan;
            ViewBag.totalProtect = totalProtect;
            ViewBag.totalXp = totalXp;
            ViewBag.totalCambio = totalCambio;

            return View(ViewBag);
        }
    }
}
