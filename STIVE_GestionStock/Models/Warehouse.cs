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
