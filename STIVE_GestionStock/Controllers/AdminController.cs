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




        // Liste des maisons
        public IActionResult ListHome()
        {
            return View(Home.GetHomes());
        }

        // Ajout maisons
        public IActionResult AddHome()
        {
            ViewBag.Home = Home.GetHomes();
            return View();
        }
        public IActionResult SubmitAddFormHome(Home home)
        {
            home.Save();
            return RedirectToAction("ListHome");
        }

        // Edit maisons
        public IActionResult EditHome(int id)
        {
            ViewBag.Home = Home.GetHome(id);
            return View();
        }

        public IActionResult SubmitEditFormHome(Home home)
        {
            home.Update();

            return RedirectToAction("ListHome");
        }


        // Delete maisons
        public IActionResult DeleteHome(int id)
        {
            Home home = Home.GetHome(id);

            if (home != null)
            {
                home.Delete();
            }

            return RedirectToAction("ListHome");
        }




        
        // Liste des fournisseurs
        public IActionResult ListProvider()
        {
            return View(Provider.GetProviders());
        }

        // Ajout fournisseurs
        public IActionResult AddProvider()
        {
            ViewBag.Provider = Provider.GetProviders();
            return View();
        }
        public IActionResult SubmitAddFormProvider(Provider provider)
        {
            provider.Save();
            return RedirectToAction("ListProvider");
        }

        // Edit fournisseurs
        public IActionResult EditProvider(int id)
        {
            ViewBag.Provider = Provider.GetProviders();
            ViewBag.Provider = Provider.GetProvider(id);
            return View();
        }

        public IActionResult SubmitEditFormProvider(Provider provider)
        {
            provider.Update();

            return RedirectToAction("ListProvider");
        }


        // Delete fournisseurs
        public IActionResult DeleteProvider(int id)
        {
            Provider provider = Provider.GetProvider(id);

            if (provider != null)
            {
                provider.Delete();
            }

            return RedirectToAction("ListProvider");
        }




        // Liste des familles
        public IActionResult ListFamily()
        {
            return View(Family.GetFamilies());
        }

        // Ajout familles
        public IActionResult AddFamily()
        {
            ViewBag.Family = Family.GetFamilies();
            return View();
        }
        public IActionResult SubmitAddFormFamily(Family family)
        {
            family.Save();
            return RedirectToAction("ListFamily");
        }

        // Edit familles
        public IActionResult EditFamily(int id)
        {
            ViewBag.Family = Family.GetFamilies();
            ViewBag.Family = Family.GetFamily(id);
            return View();
        }

        public IActionResult SubmitEditFormFamily(Family family)
        {
            family.Update();

            return RedirectToAction("ListFamily");
        }


        // Delete familles
        public IActionResult DeleteFamily(int id)
        {
            Family family = Family.GetFamily(id);

            if (family != null)
            {
                family.Delete();
            }

            return RedirectToAction("ListFamily");
        }




        // Liste des entrepots
        public IActionResult ListWarehouse()
        {
            return View(Warehouse.GetWarehouses());
        }

        // Ajout entrepots
        public IActionResult AddWarehouse()
        {
            ViewBag.Warehouse = Warehouse.GetWarehouses();
            return View();
        }
        public IActionResult SubmitAddFormWarehouse(Warehouse warehouse)
        {
            warehouse.Save();
            return RedirectToAction("ListWarehouse");
        }

        // Edit entrepots
        public IActionResult EditWarehouse(int id)
        {
            ViewBag.Warehouse = Warehouse.GetWarehouses();
            ViewBag.Warehouse = Warehouse.GetWarehouse(id);
            return View();
        }

        public IActionResult SubmitEditFormWarehouse(Warehouse warehouse)
        {
            warehouse.Update();

            return RedirectToAction("ListWarehouse");
        }


        // Delete entrepots
        public IActionResult DeleteWarehouse(int id)
        {
            Warehouse warehouse = Warehouse.GetWarehouse(id);

            if (warehouse != null)
            {
                warehouse.Delete();
            }

            return RedirectToAction("ListWarehouse");
        }

    }
}
