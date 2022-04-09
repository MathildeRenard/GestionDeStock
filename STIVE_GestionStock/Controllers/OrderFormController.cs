using Microsoft.AspNetCore.Http;
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

        // Choix du fournisseur
        public IActionResult Index()
        {
            int idProvider = _login.GetFournisseur();
            if (idProvider > 0)
            {
                ViewBag.Provider = Provider.GetProviders("ID = " + idProvider);
                return RedirectToAction("ListProducts", Provider.GetProvider(idProvider));
               // return View();
            }
            else
            {
                ViewBag.Provider = Provider.GetProviders();
                return View();
            }
            
        }

        // Liste des produits en fonction du fournisseur choisi
        public IActionResult ListProducts(Provider provider)
        {
            OrderForm orderform = new OrderForm();
            orderform.Products = Product.GetProducts("ID_Provider = " + provider.Id);
            orderform.Date = DateTime.Now;
            orderform.Provider = provider;
            orderform.ConfirmOrder = false;

            int idOrderform = _login.GetOrderForm();
            if (idOrderform == 0)
            {
                orderform.Save();
                _login.SetOrderForm(orderform.Id);
            }

            int idProvider = _login.GetFournisseur();
            if (idProvider == 0)
            {
                _login.SetFournisseur(provider.Id);
            }

            ViewBag.OrderForm = orderform;

            return View();
        }

        // Ajout du produit dans une OrderForm
        public IActionResult AddOrderForm(int Qte, int idOrderForm, int idProduct, int idFournisseur)
        {
            if (Qte > 0)
            {
                if (idProduct != 0)
                {
                    bool bAdd = true;
                    if (idOrderForm != 0)
                    {
                        OrderForm orderform = OrderForm.GetOrderForm(idOrderForm);
                        //récupération des ProductOrderForm lié au bon de commande
                        orderform.Productorderformlist = ProductOrderForm.GetProductOrdersForm("ID_OrderForm = " + orderform.Id);
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

                            return RedirectToAction("ListProducts", Provider.GetProvider(idFournisseur));
                        }
                        else
                        {
                            return RedirectToAction("ListProducts", Provider.GetProvider(idFournisseur));
                        }
                    } 
                    else
                    {
                        return RedirectToAction("ListProducts", Provider.GetProvider(idFournisseur));
                    }
                }
                else
                {
                    return RedirectToAction("ListProducts", Provider.GetProvider(idFournisseur));
                }
            }
            else
            {
                return RedirectToAction("ListProducts", Provider.GetProvider(idFournisseur));
            }
        }

        // Vue bon de commande
        public IActionResult VueOrderForm()
        {
            int idOrderform = _login.GetOrderForm();
            if (idOrderform != 0)
            {
                // Création d'un bon de commande ou si bon de commande déjà éxistant on le récupère
                OrderForm orderform = OrderForm.GetOrderForm(idOrderform);

                //récupération des ProductOrderForm lié à ce bon de commande
                orderform.Productorderformlist = ProductOrderForm.GetProductOrdersForm("ID_OrderForm = " + orderform.Id);

                ViewBag.OrderForm = orderform;

                return View();
            } else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public IActionResult ValidOrderForm()
        {
            int idOrderform = _login.GetOrderForm();
            if (idOrderform != 0)
            {
                OrderForm orderform = OrderForm.GetOrderForm(idOrderform);
                orderform.Productorderformlist = ProductOrderForm.GetProductOrdersForm("ID_OrderForm = " + orderform.Id);

                foreach (ProductOrderForm p in orderform.Productorderformlist)
                {
                    Product product = Product.GetProduct(p.Product.Id);

                    product.Quantity = product.Quantity + p.Quantity;
                    product.Update();

                }

                orderform.ConfirmOrder = true;
                orderform.Update();

                _login.SetOrderForm(0);
                _login.SetFournisseur(0);

            }
                return RedirectToAction("Index", "Home");
        }

        // Delete Product
        public IActionResult DeleteProductOrderForm(int id)
        {
            ProductOrderForm productOrderForm = ProductOrderForm.GetProductOrderForm(id);

            if (productOrderForm != null)
            {
                productOrderForm.Delete();
            }

            return RedirectToAction("VueOrderForm");
        }
    }
}
