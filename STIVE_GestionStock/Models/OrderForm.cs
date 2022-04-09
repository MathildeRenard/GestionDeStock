using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace STIVE_GestionStock.Models
{
    public class OrderForm
    {
        private int id;
        private DateTime date;
        private bool confirmOrder;
        private Provider provider;
        private List<ProductOrderForm> productorderformlist;
        private List<Product> products;

        private static string request;
        private static MySqlCommand command;
        private static MySqlConnection connection;
        private static MySqlDataReader reader;

        public OrderForm()
        {
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public Provider Provider { get => provider; set => provider = value; }
        public List<ProductOrderForm> Productorderformlist { get => productorderformlist; set => productorderformlist = value; }
        public bool ConfirmOrder { get => confirmOrder; set => confirmOrder = value; }
        public List<Product> Products { get => products; set => products = value; }

        // Add OrderForm
        public bool Save()
        {
            request = "INSERT INTO `orderform` (date, ConfirmOrder, ID_Provider ) values (@date, @confirmOrder, @idProvider); SELECT LAST_INSERT_ID()";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@date", Date));
            command.Parameters.Add(new MySqlParameter("@confirmOrder", ConfirmOrder));
            command.Parameters.Add(new MySqlParameter("@idProvider", Provider.Id));
            connection.Open();
            Id = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        //Update OrderForm
        public bool Update()
        {
            request = "Update `orderform` set date=@date, ConfirmOrder=@confirmOrder, ID_Provider=@idProvider where ID=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            command.Parameters.Add(new MySqlParameter("@date", Date));
            command.Parameters.Add(new MySqlParameter("@confirmOrder", ConfirmOrder));
            command.Parameters.Add(new MySqlParameter("@idProvider", Provider.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        //Delete OrderForm
        public bool Delete()
        {
            request = "DELETE FROM `orderform` where ID=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb == 1;
        }

        // Liste des OrdersForm
        public static List<OrderForm> GetOrdersForm(string condition = "")
        {
            List<OrderForm> ordersform = new List<OrderForm>();
            request = "SELECT ID, date, ConfirmOrder, ID_Provider FROM `orderform`";
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
                OrderForm orderform = new OrderForm()
                {
                    Id = reader.GetInt32(0),
                    Date = reader.GetDateTime(1),
                    ConfirmOrder = reader.GetBoolean(2),
                    Provider = Provider.GetProvider(reader.GetInt32(3)),
                };
                ordersform.Add(orderform);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return ordersform;

        }

        // Get by id orderForm
        public static OrderForm GetOrderForm(int id)
        {
            OrderForm orderform = null;
            request = "SELECT ID, Date, ConfirmOrder, ID_Provider FROM `orderform` where ID = @id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                orderform = new OrderForm()
                {
                    Id = reader.GetInt32(0),
                    Date = reader.GetDateTime(1),
                    ConfirmOrder = reader.GetBoolean(2),
                    Provider = Provider.GetProvider(reader.GetInt32(3)),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return orderform;
        }

        // Get by id User
/*        public static OrderForm GetOrderFormByIdUser(int id, string condition = "")
        {
            OrderForm orderform = null;
            request = "SELECT ID, date, ConfirmOrder, ID_Provider FROM `orderform` where ID_user = @id AND ConfirmOrder = false";
            if (condition != "")
            {
                request += " WHERE " + condition;
            };
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                orderform = new OrderForm()
                {
                    Id = reader.GetInt32(0),
                    Date = reader.GetDateTime(1),
                    ConfirmOrder = reader.GetBoolean(2),
                    Provider = Provider.GetProvider(reader.GetInt32(3)),
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return orderform;
        }*/
    }
}
