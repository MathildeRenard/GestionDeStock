using Microsoft.AspNetCore.Mvc;
using STIVE_GestionStock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Controllers
{
    public class LoginController : Controller
    {
        private ILogin _login;

        public LoginController(ILogin login)
        {
            _login = login;
        }
        // GET: /<controller>/
        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        public IActionResult SubmitLogin(string login, string password)
        {
           
            if (_login.LogIn(login, password))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login", new { message = "Erreur de connexion" });
            }
        }
       
    }
}
