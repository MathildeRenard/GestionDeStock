﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Models
{
    public class Role
    {

        private int id;
        private string name;

        public Role()
        {
           
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        public void setName()
        {
            if (id == 1)
            {
                name = "admin";
            }
            else if (id == 2)
            {
                name = "client";
            }
        }
    }
}
