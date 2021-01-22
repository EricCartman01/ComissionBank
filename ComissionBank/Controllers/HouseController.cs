using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models;
using ComissionBank.Services;

namespace ComissionBank.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseService _houseService;

        public HouseController(HouseService houseService)
        {
            _houseService = houseService;
        }
        public IActionResult Index()
        {
            List<House> houses = _houseService.FindAll();
            return View(houses);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _houseService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
    }
}
