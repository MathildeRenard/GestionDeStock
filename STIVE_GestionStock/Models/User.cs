using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text;

namespace STIVE_GestionStock.Models
{
    public class User
    {
        private string login;
        private int id;
        private string mail;
        private string password;
        private string lastName;
        private string firstName;
        private string adress;
        private string phone;
        private Role role;
        private static string request;
        private static MySqlConnection connection;
        private static MySqlCommand command;
        

        public User()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Password { get => password; set => password = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Login { get => login; set => login = value; }
        public Role Role { get => role; set => role = value; }

        //methode qui récupére les saisies du formulaire de connexion et verifie la validité des informations dans la base de données
        public static User GetUserLogin(string login, string password)
        {
            User user = null;
            //Faire un select si le mot de passe et le login correspondent à ceux dans la base de données.
            request = "SELECT Count(*) FROM User WHERE Login = @Login AND Password = @Password ";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("Login", login));
            //Hashage du mot de passe
            var bytes = new UTF8Encoding().GetBytes(password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            string PasswordHash = Convert.ToBase64String(hashBytes);
            command.Parameters.Add(new MySqlParameter("Password", PasswordHash));
            connection.Open();
            //vérifier si le login et le mot de passe sont présents dans la base de données
            //Faire une compraison dans la base de données.
            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count == 1)
                  {
                user = new User()
                {
                    Login = login ,
                    Password = password
                      };

                  }
            command.Dispose();
            connection.Close();
            
            return user;
        }

        //Creer un nouveau compte dans la base de données
        public void Create(String Login,String Password,String LastName,String FirstName, String Adress, Int32 Phone, String Mail)
        {
            //Pour l'instant laisser le role par defaut à 2(Client)
            Int32 Role = 2;
            request = "INSERT INTO User ( Login, Password, LastName, FirstName, Adress, Phone, Mail,ID_Role) values (@login, @password, @lastName, @firstName, @adress, @phone, @mail,@role)";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@login", Login));
            //Hashage du mot de passe
            var bytes = new UTF8Encoding().GetBytes(Password);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed())
            {
                hashBytes = algorithm.ComputeHash(bytes);
            }
            string PasswordHash = Convert.ToBase64String(hashBytes);
            command.Parameters.Add(new MySqlParameter("@password", PasswordHash));
            command.Parameters.Add(new MySqlParameter("@lastName", LastName));
            command.Parameters.Add(new MySqlParameter("@firstName", FirstName));
            command.Parameters.Add(new MySqlParameter("@adress", Adress));
            command.Parameters.Add(new MySqlParameter("@phone", Phone));
            command.Parameters.Add(new MySqlParameter("@mail", Mail));
            command.Parameters.Add(new MySqlParameter("@role", Role));
            connection.Open();
            command.ExecuteScalar();
            command.Dispose();
            connection.Close();
            
        }

         //méthode de suppression inutilisée pour le moment mais sera gérable par l'admin.
        public bool Delete()
        {
            request = "DELETE FROM User where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb == 1;
        }

        public void disconnection()
        {
            //ISession.Clear();
        }
    }
}
