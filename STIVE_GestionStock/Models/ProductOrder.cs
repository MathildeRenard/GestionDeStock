using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace STIVE_GestionStock.Models
{
    public class ProductOrder
    {
        private int id;
        private int quantity;
        private decimal total;
        private Order order;
        private Product product;

        private static string request;
        private static MySqlCommand command;
        private static MySqlConnection connection;
        private static MySqlDataReader reader;

        public ProductOrder()
        {
        }

        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal Total { get => total; set => total = value; }
        public Order Order { get => order; set => order = value; }
        public Product Product { get => product; set => product = value; }

        // Add ProductOrder
        public bool Save()
        {
            request = "INSERT INTO productorder (Quantity, Total, ID_Product , ID_Order) values (@quantity, @total, @id_product, @id_order); SELECT LAST_INSERT_ID()";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@quantity", Quantity));
            command.Parameters.Add(new MySqlParameter("@total", Total));
            command.Parameters.Add(new MySqlParameter("@id_product", Product.Id));
            command.Parameters.Add(new MySqlParameter("@id_order", Order.Id));
            connection.Open();
            Id = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        //Update ProductOrder
        public bool Update()
        {
            request = "Update productorder set Quantity=@quantity, Total=@total, ID_Product=@id_product, ID_Order=@id_order where ID=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            command.Parameters.Add(new MySqlParameter("@quantity", Quantity));
            command.Parameters.Add(new MySqlParameter("@total", Total));
            command.Parameters.Add(new MySqlParameter("@id_product", Product.Id));
            command.Parameters.Add(new MySqlParameter("@id_order", Order.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        //Delete ProductOrder
        public bool Delete()
        {
            request = "DELETE FROM productorder where ID=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb == 1;
        }

        // Liste des ProductOrder
        public static List<ProductOrder> GetProductOrders(string condition = "")
        {
            List<ProductOrder> productorders = new List<ProductOrder>();
            request = "SELECT ID, Quantity, Total, ID_Product , ID_Order FROM productorder";
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
                ProductOrder productorder = new ProductOrder()
                {
                    Id = reader.GetInt32(0),
                    Quantity = reader.GetInt32(1),
                    Total = reader.GetDecimal(2),
                    Product = Product.GetProduct(reader.GetInt32(3)),
                    Order = Order.GetOrder(reader.GetInt32(4))
                };
                productorders.Add(productorder);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return productorders;

        }

        // Get by id ProductOrder
        public static ProductOrder GetProductOrder(int id)
        {
            ProductOrder productorder = null;
            request = "SELECT ID, Quantity, Total, ID_Product, ID_Order FROM productorder where ID = @id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                productorder = new ProductOrder()
                {
                    Id = reader.GetInt32(0),
                    Quantity = reader.GetInt32(1),
                    Total = reader.GetDecimal(2),
                    Product = Product.GetProduct(reader.GetInt32(3)),
                    Order = Order.GetOrder(reader.GetInt32(4))
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return productorder;
        }
    }
}
