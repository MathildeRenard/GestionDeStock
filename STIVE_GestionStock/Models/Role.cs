using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace STIVE_GestionStock.Models
{
    public class Role
    {

        private int id;
        private string name;
        private static string request;
        private static MySqlConnection connection;
        private static MySqlCommand command;

        public Role()
        {
           
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public void setName()
        {
            request = "SELECT Name FROM Role WHERE id = @Id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("Id", id));
            connection.Open();
            name = command.ExecuteScalar().ToString(); ;
            command.Dispose();
            connection.Close();
        }
        public List<Role> GetRoles()
        {
            List<Role> roles = new List<Role>();
            request = "SELECT * FROM Role";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);

            connection.Open();
           
            MySqlDataReader reader = command.ExecuteReader();

            while(reader.Read()){
                Role role = new Role()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                }; 
                roles.Add(role);
            };


            reader.Close();
            command.Dispose();
            connection.Close();
            return roles;
        }
    }
}
