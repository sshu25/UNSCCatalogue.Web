using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNSCCatalogue.Web.Models;

namespace UNSCCatalogue.Web.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            UNSCdbContext db = new UNSCdbContext(); 
            List<Product> products = db.Products.ToList();
            return View(products);
        }
    }
}