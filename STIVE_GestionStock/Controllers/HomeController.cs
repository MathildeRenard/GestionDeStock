using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using STIVE_GestionStock.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using STIVE_GestionStock.ViewModels;

namespace STIVE_GestionStock.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View(Product.GetProducts("Available = true"));
        }

        public IActionResult ShowProduct(int id)
        {
            return View(Product.GetProduct(id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //Redirections pour les boutons Se connecter et s'inscrire
        public IActionResult Connection()
        {
            return View("/Views/Login/Index.cshtml");
        }
        public IActionResult Register()
        {
            return View("/Views/Register/Index.cshtml");
        }
    }
}
