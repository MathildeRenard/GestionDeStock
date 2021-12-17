using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace STIVE_GestionStock.Models
{
    public class Home
    {
        private int id_Home;
        private string name;

        private static string request;
        private static MySqlCommand command;
        private static MySqlConnection connection;
        private static MySqlDataReader reader;


        public Home()
        {
        }

        public string Name { get => name; set => name = value; }
        public int Id_Home { get => id_Home; set => id_Home = value; }

        // Get by id Home
        public static Home GetHome(int id)
        {
            Home home = null;
            request = "SELECT ID, Name FROM home where ID = @id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                home = new Home()
                {
                    Id_Home = reader.GetInt32(0),
                    Name = reader.GetString(1),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return home;
        }
    }
}
