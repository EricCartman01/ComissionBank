using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models;
using ComissionBank.Models.Enums;

namespace ComissionBank.Controllers
{
    public class ExchangeController : Controller
    {
        public IActionResult Index()
        {
            List<Exchange> exchanges = new List<Exchange>();

            Advisor advisor1 = new Advisor(1, "Leonardo Gomes", "LG", "leonardo.gomes@bankrio.com.br");
            Advisor advisor2 = new Advisor(2, "Raquel Pena", "RP", "raquel.pena@bankrio.com.br");
            Advisor advisor3 = new Advisor(3, "Leonardo Principe", "LP", "leonardo.principe@bankrio.com.br");
            Advisor advisor4 = new Advisor(4, "Carlos Rocha", "CR", "carlos.rocha@bankrio.com.br");

            exchanges.Add(new Exchange(1020, new DateTime(2020, 01, 10), advisor1, Order.Compra, Currency.Dolar, 1000, 1200, 5.70, ComissionType.Nominal, 10.00, 1.00, 200.00));
            exchanges.Add(new Exchange(1020, new DateTime(2020, 02, 20), advisor2, Order.Compra, Currency.Dolar, 3000, 900, 4.10, ComissionType.Nominal, 80.00, 1.00, 200.00));
            exchanges.Add(new Exchange(1020, new DateTime(2020, 03, 30), advisor3, Order.Compra, Currency.Dolar, 7000, 200, 1.70, ComissionType.Nominal, 10.00, 1.00, 200.00));
            exchanges.Add(new Exchange(1020, new DateTime(2020, 04, 10), advisor4, Order.Compra, Currency.Dolar, 9000, 100, 2.30, ComissionType.Nominal, 30.00, 1.00, 200.00));
            return View(exchanges);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
