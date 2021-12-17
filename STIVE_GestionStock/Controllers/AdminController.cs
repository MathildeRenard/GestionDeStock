using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STIVE_GestionStock.Models;

namespace STIVE_GestionStock.Controllers
{
    public class AdminController : Controller
    {   
        // Vue Admin
        public IActionResult Admin()
        {
            return View();
        }

        // Liste des produits
        public IActionResult ListProduct()
        {
            return View(Product.GetProducts());
        }

        // Ajout produits
        public IActionResult AddProduct()
        {
            ViewBag.Home = Home.GetHomes();
            ViewBag.Family = Family.GetFamilies();
            ViewBag.Warehouse = Warehouse.GetWarehouses();

            return View();
        }        
        public IActionResult SubmitAddFormProduct(Product product, Home home, Family family, Warehouse warehouse)
        {
            product.Home = home;
            product.Family = family;
            product.Warehouse = warehouse;
            product.Save();

            return RedirectToAction("ListProduct");
        }

        // Edit produits
        public IActionResult EditProduct(int id)
        {
            ViewBag.Home = Home.GetHomes();
            ViewBag.Family = Family.GetFamilies();
            ViewBag.Warehouse = Warehouse.GetWarehouses();
            ViewBag.Product = Product.GetProduct(id);
            return View();
        }

        public IActionResult SubmitEditFormProduct(Product product, Home home, Family family, Warehouse warehouse)
        {
            product.Home = home;
            product.Family = family;
            product.Warehouse = warehouse;
            product.Update();

            return RedirectToAction("ListProduct");
        }


        // Delete Product
        public IActionResult DeleteProduct(int id)
        { 
        Product product = Product.GetProduct(id);

        if (product != null)
            {
                product.Delete();
            }

            return RedirectToAction("ListProduct");
        }

    }
}
