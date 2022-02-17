using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STIVE_GestionStock.Models;
using STIVE_GestionStock.Services;
using STIVE_GestionStock.ViewModels;

namespace STIVE_GestionStock.Controllers
{
    public class UserController : Controller
    {
        private ILogin _login;

        public UserController(ILogin login)
        {
            _login = login;
        }
        public IActionResult Index()
        {
            //restreindre l'accès de la page aux admin
            if (_login.GetRole() != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

                User user = new User();
              

                return View(user.GetUsers());
            
        }
       

        //Ne pouvoir accéder à cette action que si on est connecté en tant qu'admin
        public IActionResult Update(int id)
        {

            //restreindre l'accès de la page aux admin
            if (_login.GetRole() != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
            //envoyer les informations pour remplir les input avec liste déroulante
            Role role = new Role();
            User user = new User();
            UserViewModels userViewModels = new UserViewModels()
            {
                listRoles = role.GetRoles(),
                user = user.GetUser(id)

            };
            return View(userViewModels);
            

        }

        public IActionResult MakeUpdate(int Id,string Login,string FirstName,string LastName,int Phone,string Adress,string Mail,int IdRole,string password)
        {

            User user = new User();
            user.Update(Id,  Login,  FirstName,  LastName,  Phone,  Adress,  Mail,  IdRole,password);
            return RedirectToAction("Index", "User");

        }
        public IActionResult Add()
        {
            //restreindre l'accès de la page aux admin
            if (_login.GetRole() != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
            Role role =new();
            
            return View(role.GetRoles());

        }
        public IActionResult MakeAdd( string Login, string FirstName, string LastName, int Phone, string Adress, string Mail, int IdRole,string password)
        {

            User user = new User();
            user.Add( Login, FirstName, LastName, Phone, Adress, Mail, IdRole,password);
            return RedirectToAction("Index", "User");

        }
        public IActionResult Delete(int id)
        {
            //restreindre l'accès de la page aux admin
            if (_login.GetRole() != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }
            User user = new User();
            user.Delete(id);
            return RedirectToAction("Index", "User");

        }
    }
}
