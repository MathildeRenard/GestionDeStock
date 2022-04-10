using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Models
{
    public class ProductOrderForm
    {
        private int id;
        private int quantity;
        private OrderForm orderform;
        private Product product;
        private static string request;
        private static MySqlConnection connection;
        private static MySqlCommand command;
        private static MySqlDataReader reader;

        public ProductOrderForm()
        {
        }

        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public OrderForm Orderform { get => orderform; set => orderform = value; }
        public Product Product { get => product; set => product = value; }

        // Add ProductOrderForm
        public bool Save()
        {
            request = "INSERT INTO productorderform (Quantity, ID_Product , ID_OrderForm) values (@quantity, @id_product, @id_orderform); SELECT LAST_INSERT_ID()";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@quantity", Quantity));
            command.Parameters.Add(new MySqlParameter("@id_product", Product.Id));
            command.Parameters.Add(new MySqlParameter("@id_orderform", Orderform.Id));
            connection.Open();
            Id = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        //Update ProductOrderForm
        public bool Update()
        {
            request = "Update productorderform set Quantity=@quantity, ID_Product=@id_product, ID_OrderForm=@id_orderform where ID=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            command.Parameters.Add(new MySqlParameter("@quantity", Quantity));
            command.Parameters.Add(new MySqlParameter("@id_product", Product.Id));
            command.Parameters.Add(new MySqlParameter("@id_orderform", Orderform.Id));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        //Delete ProductOrderForm
        public bool Delete()
        {
            request = "DELETE FROM productorderform where ID=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb == 1;
        }

        // Liste des ProductOrderForm
        public static List<ProductOrderForm> GetProductOrdersForm(string condition = "")
        {
            List<ProductOrderForm> productordersform = new List<ProductOrderForm>();
            request = "SELECT ID, Quantity, ID_Product , ID_OrderForm FROM productorderform";
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
                ProductOrderForm productorderform = new ProductOrderForm()
                {
                    Id = reader.GetInt32(0),
                    Quantity = reader.GetInt32(1),
                    Product = Product.GetProduct(reader.GetInt32(2)),
                    Orderform = OrderForm.GetOrderForm(reader.GetInt32(3))
                };
                productordersform.Add(productorderform);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return productordersform;

        }

        // Get by id ProductOrderForm
        public static ProductOrderForm GetProductOrderForm(int id)
        {
            ProductOrderForm productOrderForm = null;
            request = "SELECT ID, Quantity, ID_Product, ID_OrderForm FROM productorderform where ID = @id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("id", id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                productOrderForm = new ProductOrderForm()
                {
                    Id = reader.GetInt32(0),
                    Quantity = reader.GetInt32(1),
                    Product = Product.GetProduct(reader.GetInt32(2)),
                    Orderform = OrderForm.GetOrderForm(reader.GetInt32(3))
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return productOrderForm;
        }
    }
}
