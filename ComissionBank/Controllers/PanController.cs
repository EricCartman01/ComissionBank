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

        public async Task<IActionResult> Index()
        {
            List<Pan> pans = await _panService.Top(50);
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
            _panService.Import();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _panService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            
            return View(obj);

        }
    }
}
