using Microsoft.AspNetCore.Mvc;
using STIVE_GestionStock.Models;
using STIVE_GestionStock.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STIVE_GestionStock.Controllers
{
    public class OrderFormController : Controller
    {
        private ILogin _login;
        public OrderFormController(ILogin login)
        {
            _login = login;
        }

        public IActionResult SubmitOrderForm(Provider provider)
        {
/*            product.Home = home;
            product.Family = family;
            product.Warehouse = warehouse;
            product.Save(); 
*/
            // renvoyer vers la liste des produits en fonction du fournisseur choisis
            return RedirectToAction("ListProduct");
        }


        // Afficher la liste des produits en fonction du fournisseur choisis
        // Permettre de choisir une quantité sur chaque produit
        // Au moment de commandé, ajouter tout les produit ou la quantié est > 0 au bon de commande
        public IActionResult Index()
        {
            ViewBag.Provider = Provider.GetProviders();
            return View();
        }
        /*public IActionResult ListProduct(int idProduct, int idWarehouse, int Qte)
        {
            // Récupérer les infos sur l'utilisateur connecté par la session
            User user = new User();
            user = user.GetUser(_login.GetIdLogin());

            // Création d'un bon de commande ou si bon de commande déjà éxistant on le récupère
            OrderForm orderform = OrderForm.GetOrderFormByIdUser(user.Id);
            if (orderform != null)
            {
                //récupération des ProductOrderForm lié à ce bon de commande
                orderform.Productorderformlist = ProductOrderForm.GetProductOrdersForm("ID_OrderForm = " + orderform.Id);
            }
            else
            {
                orderform = new OrderForm();
                orderform.Date = DateTime.Now;
                orderform.ConfirmOrder = false;
                orderform.User = user;

                orderform.Save();
            }

            if (idProduct != 0)
            {
                bool bAdd = true;
                // Test si le produit est déjà dans le bon de commande
                foreach (ProductOrderForm p in orderform.Productorderformlist)
                {
                    if (p.Product.Id == idProduct)
                    {
                        bAdd = false;
                        p.Quantity = p.Quantity + Qte;
                        p.Update();
                    }
                }

                if (bAdd)
                {
                    // Ajout du product dans l'OrderForm Via l'objet ProductOrderForm
                    ProductOrderForm productOrderForm = new ProductOrderForm();
                    productOrderForm.Orderform = orderform;
                    productOrderForm.Product = Product.GetProduct(idProduct);
                    productOrderForm.Quantity = Qte;

                    productOrderForm.Save();

                    // Ajout du productOrderForm dans la liste des products de l'OrderForm
                    orderform.Productorderformlist.Add(productOrderForm);
                }
            }

            ViewBag.OrderForm = orderform;

            return View();
        }*/
        // Delete Product
        public IActionResult DeleteProductOrderForm(int id)
        {
            ProductOrderForm productOrderForm = ProductOrderForm.GetProductOrderForm(id);

            if (productOrderForm != null)
            {
                productOrderForm.Delete();
            }

            return RedirectToAction("Index");
        }
    }
}
