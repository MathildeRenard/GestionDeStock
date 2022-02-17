using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace STIVE_GestionStock.Models
{
    public class Order
    {
        private int id;
        private DateTime date;
        private decimal total;
        private bool confirmOrder;
        private User user;
        //private List<ProductOrder> productorderlist;

        private static string request;
        private static MySqlCommand command;
        private static MySqlConnection connection;
        private static MySqlDataReader reader;

        public Order()
        {
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public decimal Total { get => total; set => total = value; }

        public bool ConfirmOrder { get => confirmOrder; set => confirmOrder = value; }

        public User User { get => user; set => user = value; }

        //public List<ProductOrder> Productorderlist { get => productorderlist; set => productorderlist = value; }

        // Add Order
        public bool Save()
        {
            request = "INSERT INTO Order (Date, Total, ConfirmOrder, ID_User ) values (@date, @total, @confirmOrder, @idUser); SELECT LAST_INSERT_ID()";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@date", Date));
            command.Parameters.Add(new MySqlParameter("@total", Total));
            command.Parameters.Add(new MySqlParameter("@confirmOrder", ConfirmOrder));
            command.Parameters.Add(new MySqlParameter("@idUser", User.Id));
            connection.Open();
            Id = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        //Update Order
        public bool Update()
        {
            request = "Update Order set Date=@date, Total=@total, ConfirmOrder=@confirmOrder, ID_User=@idUser where ID=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            command.Parameters.Add(new MySqlParameter("@date", Date));
            command.Parameters.Add(new MySqlParameter("@total", Total));
            command.Parameters.Add(new MySqlParameter("@confirmOrder", ConfirmOrder));
            command.Parameters.Add(new MySqlParameter("@idUser", User.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        //Delete Order
        public bool Delete()
        {
            request = "DELETE FROM Order where ID=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb == 1;
        }

        // Liste des Orders
        public static List<Order> GetOrders(string condition = "")
        {
            List<Order> orders = new List<Order>();
            request = "SELECT ID, Date, Total, ConfirmOrder, ID_User FROM Order";
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
                Order order = new Order()
                {
                    Id = reader.GetInt32(0),
                    Date = reader.GetDateTime(1),
                    Total = reader.GetDecimal(2),
                    ConfirmOrder = reader.GetBoolean(3),
                    User = User.GetUser(reader.GetInt32(4))
                };
                orders.Add(order);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return orders;

        }

        // Get by id order
        public static Order GetOrder(int id)
        {
            Order order = null;
            request = "SELECT ID, Date, Total, ConfirmOrder, ID_User FROM Order where ID = @id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                order = new Order()
                {
                    Id = reader.GetInt32(0),
                    Date = reader.GetDateTime(1),
                    Total = reader.GetDecimal(2),
                    ConfirmOrder = reader.GetBoolean(3),
                    User = User.GetUser(reader.GetInt32(4))
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return order;
        }
    }
}
