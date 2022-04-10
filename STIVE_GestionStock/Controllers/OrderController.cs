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

                order.Productorderlist = ProductOrder.GetProductOrders("ID_Order = " + order.Id);
            }

            if ( idProduct != 0 )
            {
                Product product = Product.GetProduct(idProduct);
                int qteDispo = product.Quantity - Qte;
                if (qteDispo < 0 && product.Auto_replenishment == false)
                {
                    return RedirectToAction("Index", "Home");
                }

                bool bAdd = true;
                // Test si le produit est déjà dans la commande
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
                productOrder.Product = product;
                productOrder.Quantity = Qte;
                productOrder.Total = (Qte * productOrder.Product.Unit_price);

                productOrder.Save();

                // Ajout du productOrder dans la liste des products de l'Order
                order.Productorderlist.Add(productOrder);
                }

                product.Quantity = product.Quantity - Qte;
                product.Update();
            }

            ViewBag.Order = order;

            return View();
        }

        public IActionResult ValidOrder()
        {
            // Récupérer les infos sur l'utilisateur connecté par la session
            User user = new User();
            user = user.GetUser(_login.GetIdLogin());
            Order order = Order.GetOrderByIdUser(user.Id);

            if (order != null)
            {
                order.Productorderlist = ProductOrder.GetProductOrders("ID_Order = " + order.Id);

                foreach (ProductOrder p in order.Productorderlist)
                {
                    Product product = Product.GetProduct(p.Product.Id);

                    int qteDispo = product.Quantity - p.Quantity;

                    if (qteDispo < 0)
                    {
                        Provider provider = Provider.GetProvider(product.Provider.Id);

                        OrderForm orderform = new OrderForm();
                        orderform.Date = DateTime.Now;
                        orderform.Provider = provider;
                        orderform.ConfirmOrder = true;

                        orderform.Save();

                        ProductOrderForm productOrderForm = new ProductOrderForm();
                        productOrderForm.Orderform = orderform;
                        productOrderForm.Product = product;
                        productOrderForm.Quantity = System.Math.Abs(qteDispo);

                        productOrderForm.Save();

                        product.Quantity = product.Quantity + System.Math.Abs(qteDispo);
                        product.Update();
                    }

                    product.Quantity = product.Quantity - p.Quantity;
                    product.Update();

                }

                order.ConfirmOrder = true;
                order.Update();

            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteOrder()
        {
            // Récupérer les infos sur l'utilisateur connecté par la session
            User user = new User();
            user = user.GetUser(_login.GetIdLogin());
            Order order = Order.GetOrderByIdUser(user.Id);

            if (order != null)
            {
                order.Productorderlist = ProductOrder.GetProductOrders("ID_Order = " + order.Id);

                foreach (ProductOrder p in order.Productorderlist)
                {
                    Product product = Product.GetProduct(p.Product.Id);

                    product.Quantity = product.Quantity + p.Quantity;
                    product.Update();

                    p.Delete();
                }

                order.Delete();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
        }

        // Delete Product
        public IActionResult DeleteProductOrder(int id, int Qte)
        {
            ProductOrder productOrder = ProductOrder.GetProductOrder(id);

            if (productOrder != null)
            {
                productOrder.Product.Quantity = productOrder.Product.Quantity + Qte;
                productOrder.Product.Update();
                productOrder.Delete();
            }

            return RedirectToAction("Index");
        }

    }
}
