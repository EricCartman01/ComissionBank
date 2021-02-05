using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Services;
using ComissionBank.Models;

namespace ComissionBank.Controllers
{
    public class ClientController : Controller
    {
        private readonly ClientService _clientService;
        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }
        public async Task<IActionResult> Index()
        {
            List<Client> clients = await _clientService.Top(100);
            return View(clients);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _clientService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        public IActionResult Import()
        {
            var lista = _clientService.Import();
            return View(lista);
        }

        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var obj = _clientService.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Delete(int id)
        {
            _clientService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
