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


        // Insert home
        public bool Save()
        {
            request = "INSERT INTO home (Name) values (@Name); SELECT LAST_INSERT_ID()";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@Name", Name));

            connection.Open();
            Id_Home = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id_Home > 0;
        }

        //Update home
        public bool Update()
        {
            request = "Update home set Name=@Name where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id_Home));
            command.Parameters.Add(new MySqlParameter("@Name", Name));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        // Delete home
        public bool Delete()
        {
            request = "DELETE FROM home where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id_Home));
            connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb == 1;
        }

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
        // Liste Home
        public static List<Home> GetHomes()
        {
            List<Home> homes = new List<Home>();
            request = "SELECT ID, Name FROM home";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Home home = new Home()
                {
                    Id_Home = reader.GetInt32(0),
                    Name = reader.GetString(1),
                };
                homes.Add(home);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return homes;
        }
    }
}
