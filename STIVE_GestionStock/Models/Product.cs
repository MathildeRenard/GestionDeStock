using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
