using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Models;
using ComissionBank.Models.Enums;
using ComissionBank.Models.ViewModels;
using ComissionBank.Services;
using ComissionBank.Services.Exceptions;

namespace ComissionBank.Controllers
{
    public class ExchangeController : Controller
    {
        private readonly ExchangeService _exchangeService;

        public ExchangeController(ExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }
        public async Task<IActionResult> Index()
        {
            var exchanges = await _exchangeService.FindAll();
            return View(exchanges);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Create(Exchange exchange)
        {
            _exchangeService.Insert(exchange);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _exchangeService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _exchangeService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Edit(int id, Exchange exchange)
        {
            if(id != exchange.Id)
            {
                return BadRequest();
            }

            try
            {
                _exchangeService.Update(exchange);
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

            var obj = _exchangeService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj); 
        }

        public IActionResult Import()
        {
            _exchangeService.Import();
            return RedirectToAction(nameof(Index));
        }
    }
}
