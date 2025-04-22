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
        public ActionResult Index(string search = "")
        {
            UNSCdbEntities db = new UNSCdbEntities();
            List<Product> products = db.Products.Where(x => x.Name.Contains(search)).ToList();
            ViewBag.Search = search;
            return View(products);
        }

        //public ActionResult Details(int id)
        //{
        //    UNSCdbEntities db = new UNSCdbEntities();
        //    Product prod = db.Products.Where(x => x.ID == id);
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