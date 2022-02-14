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


        // Insert Famille
        public bool Save()
        {
            request = "INSERT INTO family (Name) values (@Name); SELECT LAST_INSERT_ID()";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@Name", Name));

            connection.Open();
            Id_Family = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id_Family > 0;
        }

        //Update family
        public bool Update()
        {
            request = "Update family set Name=@Name where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id_Family));
            command.Parameters.Add(new MySqlParameter("@Name", Name));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        // Delete family
        public bool Delete()
        {
            request = "DELETE FROM family where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id_Family));
            connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb == 1;
        }


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

        // Liste Family
        public static List<Family> GetFamilies()
        {
            List<Family> families = new List<Family>();
            request = "SELECT ID, Name FROM family";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Family family = new Family()
                {
                    Id_Family = reader.GetInt32(0),
                    Name = reader.GetString(1),
                };
                families.Add(family);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return families;
        }
    }
}

