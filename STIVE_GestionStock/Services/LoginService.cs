using Microsoft.AspNetCore.Http;
using STIVE_GestionStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Services
{
    public class LoginService : ILogin
    {
        private IHttpContextAccessor _accessor;
        public LoginService(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string GetLogin()
        {
            return _accessor.HttpContext.Session.GetString("login");
        }        
        public int GetIdLogin()
        {
            return Convert.ToInt32(_accessor.HttpContext.Session.GetInt32("idLogin"));
        }

        public string GetRole()
        {
            return _accessor.HttpContext.Session.GetString("role");
        }

        public int GetFournisseur()
        {
            return Convert.ToInt32(_accessor.HttpContext.Session.GetInt32("fournisseur"));
        }        
        public int GetOrderForm()
        {
            return Convert.ToInt32(_accessor.HttpContext.Session.GetInt32("idOrderForm"));
        }

        public bool isLogged()
        {
            string test = _accessor.HttpContext.Session.GetString("isLogged");
            return test == "true";
        }

        public bool SetFournisseur(int idProvider)
        {
            _accessor.HttpContext.Session.SetInt32("fournisseur", idProvider);
            return true;
        }        
        
        public bool SetOrderForm(int idOrderForm)
        {
            _accessor.HttpContext.Session.SetInt32("idOrderForm", idOrderForm);
            return true;
        }

        public bool LogIn(string login, string password)
        {
            User u = User.GetUserLogin(login, password);
            if (u != null)
            {
                _accessor.HttpContext.Session.SetString("login", u.Login);
                _accessor.HttpContext.Session.SetInt32("idLogin", u.Id);
                _accessor.HttpContext.Session.SetString("role", u.Role.Name);
                _accessor.HttpContext.Session.SetString("isLogged", "true");
                return true;
            }
            return false;
        }
    }
}
