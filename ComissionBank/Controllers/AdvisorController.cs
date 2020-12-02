using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models.Services;
using ComissionBank.Models;
using ComissionBank.Services.Exceptions;

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
            /*List<Advisor> lista = new List<Advisor>();
            lista.Add(new Advisor(1, "Leonardo Gomes", "LM", "leonardo.gomes@bankrio.com.br"));
            lista.Add(new Advisor(2, "Raquel Pena", "RP", "Raquel.Pena@bankrio.com.br"));
            lista.Add(new Advisor(3, "Carlos Rocha", "KD", "carlos.rocha@bankrio.com.br"));
            lista.Add(new Advisor(4, "Leonardo Principe", "KD", "leonardo.principe@bankrio.com.br"));

            return View(lista);*/
            var list = _advisorService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Advisor advisor)
        {
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
            catch (DbconcurrencyException)
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
