using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STIVE_GestionStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Controllers
{
    public class RegisterController : Controller
    {
        // GET: HomeController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: HomeController1/Details/5
        public IActionResult SubmitRegister(String login,String password,String lastname,String firstname,String adress,Int32 phone,String mailadress)
        {
            User user = new User();
            User result = user.Create(login, password,lastname,firstname,adress,phone,mailadress);
            if (result != null && result.Login != "erreur")
            {
                //Si user n'est pas null,connecter le compte(pas encore fait)
                return RedirectToAction("Index", "Home");
            }
            else if (result != null && result.Login == "erreur")
            {
                ViewBag.Message = "Ce pseudo n'est pas disponible.";                
                return View("Index");
            }
            else
            {
                ViewBag.Message = "Veuillez ajouter les informations manquantes.";
                return View("Index");
            }
        }
     
    }
}
