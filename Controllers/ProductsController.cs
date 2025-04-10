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
            ViewBag.Products = products;
            return View();
        }

        public ActionResult Details(int id)
        {
            List<Product> products = new List<Product>()
            {
                new Product() { ID = 1, Name = "MA5B", Cost = 10000 },
                new Product() { ID = 2, Name = "D77 Pelican", Cost = 3000000 },
                new Product() { ID = 3, Name = "MJOLNIR Powered Assault Armor Mark IV", Cost = 2000000000 }
            };

            foreach (var product in products)
            {
                if (product.ID == id)
                {
                    ViewBag.Product = product;
                }
            }

            return View();
        }

        //public ActionResult GetProductID(string name)
        //{
        //    var products = new[]
        //    {
        //        new { ID = 1, Name = "MA5B", Cost = 10000 },
        //        new { ID = 2, Name = "D77 Pelican", Cost = 3000000 },
        //        new { ID = 3, Name = "MJOLNIR Powered Assault Armor Mark IV", Cost = 2000000000 }
        //    };

        //    if (string.IsNullOrEmpty(name)) return Content("Product name not recognized.");

        //    foreach (var product in products)
        //    {
        //        if (product.Name == name)
        //        {
        //            return Content(product.ID.ToString());
        //        }
        //    }

        //    return RedirectToAction("Index");
        //}
    }
}