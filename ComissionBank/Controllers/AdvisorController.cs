using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Services;
using ComissionBank.Models;
using ComissionBank.Services.Exceptions;
using System.Security.Cryptography;
using PagedList;

namespace ComissionBank.Controllers
{
    public class AdvisorController : Controller
    {
        private readonly AdvisorService _advisorService;

        public AdvisorController(AdvisorService advisorService)
        {
            _advisorService = advisorService;
        }

        public IActionResult Index()
        {
            var list = _advisorService.FindAll();
            return View(list);
        }

        public IActionResult Import()
        {
            var lista = _advisorService.Import();
            return View(lista);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Advisor advisor)
        {
            if(advisor.Password == null){
                advisor.Password = _advisorService.GetRandomAlphanumericString(8);
            }
            _advisorService.Insert(advisor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _advisorService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Advisor advisor)
        {
            if(id != advisor.Id)
            {
                return BadRequest();
            }

            try
            {
                _advisorService.Update(advisor);
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
            if (id == null)
            {
                return NotFound();
            }

            var obj = _advisorService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Load()
        {
            return View();
        }

    }
}
