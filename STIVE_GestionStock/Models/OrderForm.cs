using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Models
{
    public class OrderForm
    {
        private int id;
        private DateTime date;
        private Warehouse warehouse;
        private Provider provider;
        private List<ProductOrderForm> productorderformlist;
        public OrderForm()
        {
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public Warehouse Warehouse { get => warehouse; set => warehouse = value; }
        public Provider Provider { get => provider; set => provider = value; }
        public List<ProductOrderForm> Productorderformlist { get => productorderformlist; set => productorderformlist = value; }
    }
}
