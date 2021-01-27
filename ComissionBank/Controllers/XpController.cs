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
    public class XpController : Controller
    {
        private readonly XpService _xpService;

        public XpController(XpService xpService)
        {
            _xpService = xpService;
        }

        public IActionResult Index()
        {
            List<Xp> xps = _xpService.FindAll();
            return View(xps);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Xp xp)
        {
            _xpService.Insert(xp);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            
            var obj = _xpService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, Xp xp)
        {
            if(id != xp.Id)
            {
                return BadRequest();
            }

            try
            {
                _xpService.Update(xp);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch (DbConcurrencyException)
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
            
            var obj = _xpService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        public IActionResult Import()
        {
            var xps = _xpService.Import();
            return View(xps);
        }
    }
}
