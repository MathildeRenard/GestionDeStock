using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STIVE_GestionStock.Models;

namespace STIVE_GestionStock.ViewModels
{
    public class UserViewModels
    {
        //Cette classe permettra de passer deux paramètres à la vue update de employee


        public List<Role> listRoles { get; set; }
        public User user { get; set; }

        }
    }


