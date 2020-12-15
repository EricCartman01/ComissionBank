using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionBank.Services;
using ComissionBank.Models;

namespace ComissionBank.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
