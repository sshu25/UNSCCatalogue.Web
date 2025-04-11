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
            UNSCdbEntities db = new UNSCdbEntities();
            List<Product> products = db.Products.ToList();
            return View(products);
        }

        //public ActionResult Details(int id)
        //{
        //    Product prod = null;
        //    foreach (var product in products)
        //    {
        //        if (product.ID == id)
        //        {
        //            prod = product;
        //        }
        //    }

        //    return View(prod);
        //}

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