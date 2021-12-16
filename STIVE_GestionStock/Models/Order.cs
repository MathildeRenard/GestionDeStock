using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Models
{
    public class Order
    {
        private int id;
        private DateTime date;
        private User user;
        //private List<ProductOrder> productorderlist;
        public Order()
        {
        }

        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public User User { get => user; set => user = value; }
        public List<ProductOrder> Productorderlist { get => productorderlist; set => productorderlist = value; }
    }
}
