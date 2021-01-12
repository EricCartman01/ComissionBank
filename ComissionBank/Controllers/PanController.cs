using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Services;
using ComissionBank.Models;

namespace ComissionBank.Controllers
{
    public class PanController : Controller
    {
        private readonly PanService _panService;

        public PanController(PanService panService)
        {
            _panService = panService;
        }

        public IActionResult Index()
        {
            List<Pan> pans = _panService.FindAll();
            return View(pans);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {
            if(id == null){
                return NotFound();
            }

            var obj = _panService.FindById(id.Value);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Import()
        {
            var pans = _panService.Import();
            return View(pans);
        }
    }
}
