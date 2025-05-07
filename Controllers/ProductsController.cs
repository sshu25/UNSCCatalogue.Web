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

        public ActionResult Details(long id)
        {
            UNSCdbEntities db = new UNSCdbEntities();
            Product product = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            UNSCdbEntities db = new UNSCdbEntities();
            db.Products.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(long id)
        {
            UNSCdbEntities db = new UNSCdbEntities();
            Product product = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            UNSCdbEntities db = new UNSCdbEntities();
            Product existing = db.Products.Where(x => x.ID == product.ID).FirstOrDefault();
            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.DateOfPurchase = product.DateOfPurchase;
            existing.CategoryID = product.CategoryID;
            existing.BrandID = product.BrandID;
            existing.AvailabilityStatus = product.AvailabilityStatus;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            UNSCdbEntities db = new UNSCdbEntities();
            Product product = db.Products.Where(x => x.ID == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}