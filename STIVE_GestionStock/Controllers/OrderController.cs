using Microsoft.AspNetCore.Mvc;
using STIVE_GestionStock.Models;
using STIVE_GestionStock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Controllers
{
    public class OrderController : Controller
    {
        private ILogin _login;
        public OrderController(ILogin login)
        {
            _login = login;
        }
        public IActionResult Index(int idProduct, int Qte)
        {
            // Récupérer les infos sur l'utilisateur connecté par la session
            User user = new User();
            user = user.GetUser(_login.GetIdLogin());

            // Création d'une commande ou si commande déjà éxistante on la récupère
            Order order = Order.GetOrderByIdUser(user.Id);
            if ( order != null )
            {
                //récupération des ProductOrder lié à cette commande
                order.Productorderlist = ProductOrder.GetProductOrders("ID_Order = " + order.Id);
            } else
            {
                order = new Order();
                order.Date = DateTime.Now;
                order.ConfirmOrder = false;
                order.User = user;

                order.Save();
            }

            if ( idProduct != 0 )
            {
                bool bAdd = true;
                // Test si le produit est éjà dans la commande
                foreach ( ProductOrder p in order.Productorderlist )
                {
                    if ( p.Product.Id == idProduct)
                    {
                        bAdd = false;
                        p.Quantity = p.Quantity + Qte;
                        p.Total = p.Total + (Qte * p.Product.Unit_price);
                        p.Update();
                    }
                }
                
                if (bAdd)
                {
                // Ajout du product dans l'Order Via l'objet ProductOrder
                ProductOrder productOrder = new ProductOrder();
                productOrder.Order = order;
                productOrder.Product = Product.GetProduct(idProduct);
                productOrder.Quantity = Qte;
                productOrder.Total = (Qte * productOrder.Product.Unit_price);

                productOrder.Save();

                // Ajout du productOrder dans la liste des products de l'Order
                order.Productorderlist.Add(productOrder);
                }
            }

            ViewBag.Order = order;

            return View();
        }
        // Delete Product
        public IActionResult DeleteProductOrder(int id)
        {
            ProductOrder productOrder = ProductOrder.GetProductOrder(id);

            if (productOrder != null)
            {
                productOrder.Delete();
            }

            return RedirectToAction("Index");
        }

    }
}
