using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Session;

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
        private Int32 phone;
        static private Role role = new Role();
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
        public Int32 Phone { get => phone; set => phone = value; }
        public string Login { get => login; set => login = value; }
        public Role Role { get => role; set => role = value; }

        //methode qui récupére les saisies du formulaire de connexion et verifie la validité des informations dans la base de données
        public static User GetUserLogin(string login, string password)
        {
            User user = null;
            //Faire un select si le mot de passe et le login correspondent à ceux dans la base de données.
            request = "SELECT Password,User.ID_Role FROM User WHERE Login = @Login";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("Login", login));

            connection.Open();
            MySqlDataReader passwordHash = command.ExecuteReader();
            passwordHash.Read();

            //S'il y a eu une erreur lors de la saisie du login, le résultat de la requête sql lèvera une exception
            try
            {
                String SavedPasswordHash = passwordHash["Password"].ToString();
                //role à ajouter dans la classe role

                role.Id = Convert.ToInt32(passwordHash["ID_Role"]);
                //Appeler la méthode de la classe Role qui initialise le nom du role.
                role.setName();
                //Vérifier si le mot de passe correspond à celui de la base de données
                byte[] hashBytes = Convert.FromBase64String(SavedPasswordHash);
                byte[] salt = new byte[16];
                Array.Copy(hashBytes, 0, salt, 0, 16);
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);

                for (int i = 0; i < 20; i++)
                    if (hashBytes[i + 16] == hash[i])
                    {
                        user = new User()
                        {
                            Login = login,
                            Password = password,
                            Role = role

                        };

                    }
            }
            //En cas d'erreur sur le login saisi, la variable user restera à sa valeur initiale "null" et la vue renverra un message d'erreur
            catch (MySqlException)
            {

            }
            catch (ArgumentNullException)
            {

            }
            command.Dispose();
            connection.Close();

            return user;
        }

        //Creer un nouveau compte dans la base de données
        public User Create(String Login, String Password, String LastName, String FirstName, String Adress, Int32 Phone, String Mail)
        {
            User user = null;
            //Mettre le role par defaut à 2(Client)
            role.Id = 2;
            //Appeler la méthode de la classe Role qui initialise le nom du role.
            role.setName();
            request = "INSERT INTO User ( Login, Password, LastName, FirstName, Adress, Phone, Mail,ID_Role) values (@login, @password, @lastName, @firstName, @adress, @phone, @mail,@role)";
            //requete pour éviter qu'il y ait deux fois le même login dans la base de données
            String requestCheck = "SELECT COUNT(*) from User WHERE Login = @login ";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            MySqlCommand commandCheck = new MySqlCommand(requestCheck, connection);
            commandCheck.Parameters.Add(new MySqlParameter("@login", Login));
            connection.Open();
            bool check = Convert.ToBoolean(commandCheck.ExecuteScalar());


            try
            {
                command.Parameters.Add(new MySqlParameter("@login", Login));

                //Hashage du mot de passe
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                var pbkdf2 = new Rfc2898DeriveBytes(Password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string PasswordHash = Convert.ToBase64String(hashBytes);

                command.Parameters.Add(new MySqlParameter("@password", PasswordHash));
                command.Parameters.Add(new MySqlParameter("@lastName", LastName));
                command.Parameters.Add(new MySqlParameter("@firstName", FirstName));
                command.Parameters.Add(new MySqlParameter("@adress", Adress));
                command.Parameters.Add(new MySqlParameter("@phone", Phone));
                command.Parameters.Add(new MySqlParameter("@mail", Mail));
                command.Parameters.Add(new MySqlParameter("@role", role.Id));
                connection.Close();
                connection.Open();

                // si Le login n'existe pas déja
                if (!check)
                {
                    //Ajouter un try si la saisie du login n'a pas été faite
                    try
                    {
                        command.ExecuteScalar();

                        user = new User()
                        {
                            Login = Login,
                            Password = Password,
                            Role = role
                        };
                    }
                    catch (MySqlException)
                    {

                    }
                }
                /*Si le login existe déja on initialise le login en "erreur" afin de pouvoir 
                 préciser dans le controlleur, le message d'erreur qui sera envoyé à la vue.*/
                else
                {
                    user = new User()
                    {
                        Login = "erreur"
                    };
                }
            }
            catch (ArgumentNullException)
            {

            }

            command.Dispose();
            connection.Close();

            return user;

        }
        //afficher la liste des employés en mode admin
        public List<User> GetUsers()
        {

            List<User> users = new List<User>();
            request = "SELECT User.ID, FirstName,LastName,phone,mail,user.ID_Role,role.Name,Adress,Login FROM user left join role on(role.ID= user.ID_Role);";

            connection = Db.Connection;

            command = new MySqlCommand(request, connection);

            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            Console.WriteLine(reader);
            while (reader.Read())
            {
                User user = new User()
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    Phone = reader.GetInt32(3),
                    Adress = reader.GetString(7),
                    Mail = reader.GetString(4),
                    Login = reader.GetString(8),
                    Role = new Role()

                    {

                        Id = reader.GetInt32(5),
                        Name = reader.GetString(6),
                    },

                };
                users.Add(user);
            }

            reader.Close();
            command.Dispose();
            connection.Close();
            return users;
        }

        //afficher un user selon son id
        public User GetUser(int Id)
        {


            request = "SELECT User.ID, FirstName,LastName,phone,mail,user.ID_Role,role.Name,Adress,Login FROM user left join role on(role.ID= user.ID_Role) WHERE User.ID = @Id;";

            connection = Db.Connection;
            command = new MySqlCommand(request, connection);

            connection.Open();
            command.Parameters.Add(new MySqlParameter("@Id", Id));
            MySqlDataReader reader = command.ExecuteReader();

            reader.Read();
            User user = new User()
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Phone = reader.GetInt32(3),
                Adress = reader.GetString(7),
                Mail = reader.GetString(4),
                Login = reader.GetString(8),
                Role = new Role()

                {

                    Id = reader.GetInt32(5),
                    Name = reader.GetString(6),
                }



            };


            reader.Close();
            command.Dispose();
            connection.Close();
            return user;
        }

        public void Update(int Id, string Login, string FirstName, string LastName, int Phone, string Adress, string Mail, int IdRole,string password)
        {
            connection.Open();
            //vérifier que le password n'est pas vide si l'utilisateur choisi de ne pas le modifier
            if (password != null)
            {
                request = "UPDATE user SET FirstName=@firstname,LastName=@lastname,phone=@phone,Adress=@adress,Login=@login,mail=@Mail,ID_Role=@id_role,Password=@password WHERE ID=@id ";
                //Hashage du mot de passe
                byte[] salt;
                new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
                var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
                byte[] hash = pbkdf2.GetBytes(20);
                byte[] hashBytes = new byte[36];
                Array.Copy(salt, 0, hashBytes, 0, 16);
                Array.Copy(hash, 0, hashBytes, 16, 20);
                string PasswordHash = Convert.ToBase64String(hashBytes);

                command = new MySqlCommand(request, connection);
                command.Parameters.Add(new MySqlParameter("@password", PasswordHash));
            }
            else {
                request = "UPDATE user SET FirstName=@firstname,LastName=@lastname,phone=@phone,Adress=@adress,Login=@login,mail=@Mail,ID_Role=@id_role WHERE ID=@id ";
                command = new MySqlCommand(request, connection);
            }
         
           
            
           
            
            command.Parameters.Add(new MySqlParameter("@firstname", FirstName));
            command.Parameters.Add(new MySqlParameter("@lastname", LastName));
            command.Parameters.Add(new MySqlParameter("@phone", Phone));
            command.Parameters.Add(new MySqlParameter("@adress", Adress));
            command.Parameters.Add(new MySqlParameter("@login", Login));
            command.Parameters.Add(new MySqlParameter("@mail", Mail));
            command.Parameters.Add(new MySqlParameter("@id_role", IdRole));
            command.Parameters.Add(new MySqlParameter("@id", Id));

        


            command.ExecuteScalar();


            command.Dispose();
            connection.Close();
        }
        public void Add( string Login, string FirstName, string LastName, int Phone, string Adress, string Mail, int IdRole,string password)
        {
            request = "INSERT INTO user (FirstName, LastName, phone,Adress,Login,mail,ID_Role,Password) VALUES (@firstname,@lastname,@phone,@adress,@login,@Mail,@id_role,@password) ";
            connection.Open();

            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@firstname", FirstName));
            command.Parameters.Add(new MySqlParameter("@lastname", LastName));
            command.Parameters.Add(new MySqlParameter("@phone", Phone));
            command.Parameters.Add(new MySqlParameter("@adress", Adress));
            command.Parameters.Add(new MySqlParameter("@login", Login));
            command.Parameters.Add(new MySqlParameter("@mail", Mail));
            command.Parameters.Add(new MySqlParameter("@id_role", IdRole));

            //Hashage du mot de passe
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            string PasswordHash = Convert.ToBase64String(hashBytes);

            command.Parameters.Add(new MySqlParameter("@password", PasswordHash));

            command.ExecuteScalar();


            command.Dispose();
            connection.Close();
        }
        public void Delete(int id)
        {
            request = "DELETE FROM User WHERE ID=@id";
            connection.Open();
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", id));
            command.ExecuteScalar();
            command.Dispose();
            connection.Close();
        }
    }
}
