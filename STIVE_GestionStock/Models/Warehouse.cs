using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Models
{
    public class Warehouse
    {
        private int id;
        private string name;
        private string adress;

        public Warehouse()
        {
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Adress { get => adress; set => adress = value; }
    }
}
