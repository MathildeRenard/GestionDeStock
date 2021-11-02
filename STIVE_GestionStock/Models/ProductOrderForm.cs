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

        public ProductOrderForm()
        {
        }

        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public OrderForm Orderform { get => orderform; set => orderform = value; }
        public Product Product { get => product; set => product = value; }
    }
}
