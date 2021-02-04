using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models;
using ComissionBank.Services;
using ComissionBank.Services.Exceptions;

namespace ComissionBank.Controllers
{
    public class ProtectController : Controller
    {
        private readonly ProtectService _protectService;

        public ProtectController(ProtectService protectService)
        {
            _protectService = protectService;
        }
        public IActionResult Index()
        {
            List<Protect> protects = _protectService.Top(50);
            return View(protects);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Protect protect)
        {
            _protectService.Insert(protect);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _protectService.FindById(id.Value);
            
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, Protect protect)
        {
            if(id != protect.Id)
            {
                return BadRequest();
            }

            try
            {
                _protectService.Update(protect);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                return BadRequest();
            }
        }
        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _protectService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Import()
        {
            //var protects = _protectService.Import();
            //return View(protects);
            _protectService.Import();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
