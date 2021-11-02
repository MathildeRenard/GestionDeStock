using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Models
{
    public class User
    {

        private string login;
        private string password;
        private string lastname;
        private string firstname;
        private string adress;
        private int phone;
        private string mail;
        public User()
        {
        }

        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Adress { get => adress; set => adress = value; }
        public int Phone { get => phone; set => phone = value; }
        public string Mail { get => mail; set => mail = value; }

        public static User GetUserLogin(string l, string p)
        {
            User user = null;

            //Faire une compraison dans la base de données.
            //Pour simplifier le developpement, je fais une comparaison avec des données statiques.
            if (l == "toto" && p == "tata")
            {
                user = new User()
                {
                    Login = l,
                    Password = p
                };

            }

            return user;
        }
    }
}
