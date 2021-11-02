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

        public bool isLogged()
        {
            string test = _accessor.HttpContext.Session.GetString("isLogged");
            return test == "true";
        }

        public bool LogIn(string login, string password)
        {
            User u = User.GetUserLogin(login, password);
            if (u != null)
            {
                _accessor.HttpContext.Session.SetString("login", u.Login);
                _accessor.HttpContext.Session.SetString("password", u.Password);
                _accessor.HttpContext.Session.SetString("isLogged", "true");
                return true;
            }
            return false;
        }
    }
}
