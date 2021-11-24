﻿using Microsoft.AspNetCore.Http;
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

        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        // GET: HomeController1/Details/5
        public IActionResult SubmitRegister(String login,String password,String lastname,String firstname,String adress,Int32 phone,String mailadress)
        {
            User user = new User();
            User result = user.Create(login, password,lastname,firstname,adress,phone,mailadress);
            if (result != null)
            {
                //Si user n'est pas null,connecter le compte
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //Si user est null mettre un message d'erreur
                return RedirectToAction("Register", "Register", new { message = "Erreur de connexion" });
            }
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
