using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace STIVE_GestionStock.Models
{
    public class Provider
    {
        private int id;
        private string name;
        private string adress;
        private string mail;

        private static string request;
        private static MySqlCommand command;
        private static MySqlConnection connection;
        private static MySqlDataReader reader;

        public Provider()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Adress { get => adress; set => adress = value; }
        public string Mail { get => mail; set => mail = value; }

        // Insert Providers
        public bool Save()
        {
            request = "INSERT INTO provider (Name, Adress, Mail) values (@Name, @Adress, @Mail); SELECT LAST_INSERT_ID()";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@Name", Name));
            command.Parameters.Add(new MySqlParameter("@Adress", Adress));
            command.Parameters.Add(new MySqlParameter("@Mail", Mail));

            connection.Open();
            Id = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        //Update Providers
        public bool Update()
        {
            request = "Update provider set Name=@Name, Adress=@Adress, Mail=@Mail where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            command.Parameters.Add(new MySqlParameter("@Name", Name));
            command.Parameters.Add(new MySqlParameter("@Adress", Adress));
            command.Parameters.Add(new MySqlParameter("@Mail", Mail));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        // Delete Providers
        public bool Delete()
        {
            request = "DELETE FROM provider where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb == 1;
        }



        // Get by id Providers
        public static Provider GetProvider(int id)
        {
            Provider provider = null;
            request = "SELECT ID, Name, Adress, Mail FROM provider where ID = @id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                provider = new Provider()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Adress = reader.GetString(2),
                    Mail = reader.GetString(3)
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return provider;
        }

        // Liste Providers
        public static List<Provider> GetProviders(string condition = "")
        {
            List<Provider> providers = new List<Provider>();
            request = "SELECT ID, Name, Adress, mail FROM provider";
            if (condition != "")
            {
                request += " WHERE " + condition;
            };
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Provider provider = new Provider()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Adress = reader.GetString(2),
                    Mail = reader.GetString(3),
                };
                providers.Add(provider);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return providers;
        }

    }

}