using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STIVE_GestionStock.Models;

namespace STIVE_GestionStock.Services
{
    public interface ILogin
    {
        bool isLogged();
        string GetLogin();
        bool LogIn(string login, string password);
    }
}
