using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Models
{
    public class ProductOrder
    {
        private int id;
        private int quantity;
        private decimal total;
        private Order order;
        private Product product;

        public ProductOrder()
        {
        }

        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal Total { get => total; set => total = value; }
        public Order Order { get => order; set => order = value; }
        public Product Product { get => product; set => product = value; }
    }
}
