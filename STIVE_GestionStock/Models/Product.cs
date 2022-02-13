using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace STIVE_GestionStock.Models
{
    public class Product
    {
        private int id;
        private string name;
        private string description;
        private int quantity;
        private bool available;
        private int product_year;
        private bool auto_replenishment;
        private decimal unit_price;
        private decimal lot_price;
        private int quantity_lot;
        private string url_photo;
        private Home home;
        private Warehouse warehouse;
        private Family family;

        private static string request;
        private static MySqlCommand command;
        private static MySqlConnection connection;
        private static MySqlDataReader reader;

        public Product()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public bool Available { get => available; set => available = value; }
        public int Product_year { get => product_year; set => product_year = value; }
        public bool Auto_replenishment { get => auto_replenishment; set => auto_replenishment = value; }
        public decimal Unit_price { get => unit_price; set => unit_price = value; }
        public decimal Lot_price { get => lot_price; set => lot_price = value; }
        public int Quantity_lot { get => quantity_lot; set => quantity_lot = value; }
        public string Url_photo { get => url_photo; set => url_photo = value; }
        public Home Home { get => home; set => home = value; }
        public Warehouse Warehouse { get => warehouse; set => warehouse = value; }
        public Family Family { get => family; set => family = value; }

        // Insert Product
        public bool Save()
        {
            request = "INSERT INTO product (Name, Description, Quantity, Available, Product_year, Auto_replenishment, Unit_price, Lot_Price, Quantity_lot, URL_Photo, ID_Home, ID_Warehouse, ID_Family) values (@Name, @Description, @Quantity, @Available, @Product_year, @auto_replenishment, @Unit_price, @Lot_Price, @Quantity_lot, @URL_Photo, @ID_Home, @ID_Warehouse, @ID_Family); SELECT LAST_INSERT_ID()";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@Name", Name));
            command.Parameters.Add(new MySqlParameter("@Description", Description));
            command.Parameters.Add(new MySqlParameter("@Quantity", Quantity));
            command.Parameters.Add(new MySqlParameter("@Available", Available));
            command.Parameters.Add(new MySqlParameter("@Product_year", Product_year));
            command.Parameters.Add(new MySqlParameter("@auto_replenishment", Auto_replenishment));
            command.Parameters.Add(new MySqlParameter("@Unit_price", Unit_price));
            command.Parameters.Add(new MySqlParameter("@Lot_price", Lot_price));
            command.Parameters.Add(new MySqlParameter("@Quantity_lot", Quantity_lot));
            command.Parameters.Add(new MySqlParameter("@Url_photo", Url_photo));
            command.Parameters.Add(new MySqlParameter("@ID_Home", Home.Id_Home));
            command.Parameters.Add(new MySqlParameter("@ID_Warehouse", Warehouse.Id_Warehouse));
            command.Parameters.Add(new MySqlParameter("@ID_Family", Family.Id_Family));

            connection.Open();
            Id = Convert.ToInt32(command.ExecuteScalar());
            command.Dispose();
            connection.Close();
            return Id > 0;
        }

        //Update Product
        public bool Update()
        {
            request = "Update product set Name=@Name, Description=@Description, Quantity=@Quantity, Available=@Available, Product_year=@Product_year, Auto_replenishment=@Auto_remplishment, Lot_price=@Lot_price, Unit_Price=@Unit_price ,Quantity_lot=@Quantity_lot,URL_Photo=@URL_Photo, ID_Home=@ID_Home, ID_Warehouse=@ID_Warehouse, ID_Family=@ID_Family where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            command.Parameters.Add(new MySqlParameter("@Name", Name));
            command.Parameters.Add(new MySqlParameter("@Description", Description));
            command.Parameters.Add(new MySqlParameter("@Quantity", Quantity));
            command.Parameters.Add(new MySqlParameter("@Available", Available));
            command.Parameters.Add(new MySqlParameter("@Product_year", Product_year));
            command.Parameters.Add(new MySqlParameter("@Auto_remplishment", Auto_replenishment));
            command.Parameters.Add(new MySqlParameter("@Unit_price", Unit_price));
            command.Parameters.Add(new MySqlParameter("@Lot_price", Lot_price));
            command.Parameters.Add(new MySqlParameter("@Quantity_lot", Quantity_lot));
            command.Parameters.Add(new MySqlParameter("@Url_photo", Url_photo));
            command.Parameters.Add(new MySqlParameter("@ID_Home", Home.Id_Home));
            command.Parameters.Add(new MySqlParameter("@ID_Warehouse", Warehouse.Id_Warehouse));
            command.Parameters.Add(new MySqlParameter("@ID_Family", Family.Id_Family));
            connection.Open();
            int nbRow = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nbRow == 1;
        }

        // Delete Product
        public bool Delete()
        {
            request = "DELETE FROM product where id=@id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("@id", Id));
            connection.Open();
            int nb = command.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            return nb == 1;
        }

        // Get by id Product
        public static Product GetProduct(int Id)
        {
            Product product = null;
            request = "SELECT ID, Name, Description, Quantity, Available, Product_year, Auto_replenishment, Unit_price, Lot_Price, Quantity_lot, URL_Photo, ID_Home, ID_Warehouse, ID_Family FROM product where Id= @Id";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            command.Parameters.Add(new MySqlParameter("Id", Id));
            connection.Open();
            reader = command.ExecuteReader();
            if (reader.Read())
            {
                product = new Product()
                {   
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Quantity = reader.GetInt32(3),
                    Available = reader.GetBoolean(4),
                    Product_year = reader.GetInt32(5),
                    Auto_replenishment = reader.GetBoolean(6),
                    unit_price = reader.GetDecimal(7),
                    Lot_price = reader.GetDecimal(8),
                    Quantity_lot = reader.GetInt32(9),
                    Url_photo = reader.GetString(10),
                    Home = Home.GetHome(reader.GetInt32(11)),
                    Warehouse = Warehouse.GetWarehouse(reader.GetInt32(12)),
                    Family = Family.GetFamily(reader.GetInt32(13))
                };
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return product;
        }

        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            request = "SELECT ID, Name, Description, Quantity, Available, Product_year, Auto_replenishment, Unit_price, Lot_Price, Quantity_lot, URL_Photo, ID_Home, ID_Warehouse, ID_Family FROM product";
            connection = Db.Connection;
            command = new MySqlCommand(request, connection);
            connection.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Product product = new Product()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Quantity = reader.GetInt32(3),
                    Available = reader.GetBoolean(4),
                    Product_year = reader.GetInt32(5),
                    Auto_replenishment = reader.GetBoolean(6),
                    unit_price = reader.GetDecimal(7),
                    Lot_price = reader.GetDecimal(8),
                    Quantity_lot = reader.GetInt32(9),
                    Url_photo = reader.GetString(10),
                    Home = Home.GetHome(reader.GetInt32(11)),
                    Warehouse = Warehouse.GetWarehouse(reader.GetInt32(12)),
                    Family = Family.GetFamily(reader.GetInt32(13))
                };
                products.Add(product);
            }
            reader.Close();
            command.Dispose();
            connection.Close();
            return products;
        }
    }
}
