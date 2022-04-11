using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace STIVE_GestionStock.Models
{
    public class Warehouse
    {
        private int id_Warehouse;
        private string name;
        private string adress;

        private static string request;
        private static MySqlCommand command;
        private static MySqlConnection connection;
        private static MySqlDataReader reader;

        public Warehouse()
        {
        }

        public string Name { get => name; set => name = value; }
        public string Adress { get => adress; set => adress = value; }
        public int Id_Warehouse { get => id_Warehouse; set => id_Warehouse = value; }


        // Insert Warehouse
        public bool Save()
        {
            request = "INSERT INTO warehouse (Name, Adress) values (@Name, @Adress); SELECT LAST_INSERT_ID()";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@Name", Name));
            command.Parameters.Add(new MySqlParameter("@Adress", Adress));

            connection.Open();
            Id_Warehouse = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id_Warehouse > 0;
        }

        //Update Warehouse
        public bool Update()
        {
            request = "Update warehouse set Name=@Name, Adress=@Adress where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id_Warehouse));
            command.Parameters.Add(new MySqlParameter("@Name", Name));
            command.Parameters.Add(new MySqlParameter("@Adress", Adress));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        // Delete Warehouse
        public bool Delete()
        {
            request = "DELETE FROM warehouse where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id_Warehouse));
            connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb == 1;
        }



        // Get by id Warehouse
        public static Warehouse GetWarehouse(int id)
        {
            Warehouse warehouse = null;
            request = "SELECT ID, Name, Adress FROM warehouse where ID = @id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                warehouse = new Warehouse()
                {
                    id_Warehouse = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Adress = reader.GetString(2)
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return warehouse;
        }

        // Liste Warehouse
        public static List<Warehouse> GetWarehouses()
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            request = "SELECT ID, Name, Adress FROM warehouse";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Warehouse warehouse = new Warehouse()
                {
                    Id_Warehouse = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Adress = reader.GetString(2),
                };
                warehouses.Add(warehouse);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return warehouses;
        }
    }
}
