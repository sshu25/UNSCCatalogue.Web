using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using UNSCCatalogue.Web.Models;

namespace UNSCCatalogue.Web.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            List<Product> products = new List<Product>()
            {
                new Product() { ID = 1, Name = "MA5B", Cost = 10000 },
                new Product() { ID = 2, Name = "D77 Pelican", Cost = 3000000 },
                new Product() { ID = 3, Name = "MJOLNIR Powered Assault Armor Mark IV", Cost = 2000000000 }
            };
            return View(products);
        }

        public ActionResult Details(int id)
        {
            List<Product> products = new List<Product>()
            {
                new Product() { ID = 1, Name = "MA5B", Cost = 10000 },
                new Product() { ID = 2, Name = "D77 Pelican", Cost = 3000000 },
                new Product() { ID = 3, Name = "MJOLNIR Powered Assault Armor Mark IV", Cost = 2000000000 }
            };

            Product prod = null;
            foreach (var product in products)
            {
                if (product.ID == id)
                {
                    prod = product;
                }
            }

            return View(prod);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            return View();
        }
    }
}