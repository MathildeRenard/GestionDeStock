using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace STIVE_GestionStock.Models
{
    public class Family
    {

        private int id_Family;
        private string name;

        private static string request;
        private static MySqlCommand command;
        private static MySqlConnection connection;
        private static MySqlDataReader reader;

        public Family()
        {
        }

        public int Id_Family { get => id_Family; set => id_Family = value; }
        public string Name { get => name; set => name = value; }

        // Get by id Family
        public static Family GetFamily(int id)
        {
            Family family = null;
            request = "SELECT ID, Name FROM family where ID = @id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                family = new Family()
                {
                    Id_Family = reader.GetInt32(0),
                    Name = reader.GetString(1),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return family;
        }
    }
}
