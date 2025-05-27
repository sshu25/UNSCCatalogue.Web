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
        public ActionResult Index(string search = "", string sortColumn = "ID", string iconClass = "fa-sort-asc", int pageNo = 1)
        {
            UNSCdbContext db = new UNSCdbContext();
            List<Product> products = db.Products.Where(x => x.Name.Contains(search)).ToList();
            ViewBag.Search = search;
            ViewBag.SortColumn = sortColumn;
            ViewBag.IconClass = iconClass;

            // Sorting
            if (ViewBag.SortColumn == "ID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(x => x.ID).ToList();
                else
                    products = products.OrderByDescending(x => x.ID).ToList();
            }
            else if (ViewBag.SortColumn == "Name")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(x => x.Name).ToList();
                else
                    products = products.OrderByDescending(x => x.Name).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(x => x.Price).ToList();
                else
                    products = products.OrderByDescending(x => x.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(x => x.DOP).ToList();
                else
                    products = products.OrderByDescending(x => x.DOP).ToList();
            }
            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(x => x.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(x => x.AvailabilityStatus).ToList();
            }
            else if (ViewBag.SortColumn == "Brand")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(x => x.Brand.Name).ToList();
                else
                    products = products.OrderByDescending(x => x.Brand.Name).ToList();
            }
            else if (ViewBag.SortColumn == "Category")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(x => x.Category.Name).ToList();
                else
                    products = products.OrderByDescending(x => x.Category.Name).ToList();
            }

            // Paging
            int recordsPerPage = 5;
            int totalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(recordsPerPage)));
            int skippedRecords = (pageNo - 1) * recordsPerPage; // Amount of records on previous pages, so skip previous pages and display what's next
            ViewBag.PageNo = pageNo;
            ViewBag.TotalPages = totalPages;
            products = products.Skip(skippedRecords).Take(recordsPerPage).ToList();
            return View(products);
        }

        public ActionResult Details(long id)
        {
            UNSCdbContext db = new UNSCdbContext();
            Product product = db.Products.Where(x => x.ID == id).FirstOrDefault();
            return View(product);
        }

        public ActionResult Create()
        {
            UNSCdbContext db = new UNSCdbContext();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "ID, Name, Price, DOP, Availability Status, CategoryID, BrandID, Photo")] Product product)
        {
            if (ModelState.IsValid)
            {

                UNSCdbContext db = new UNSCdbContext();
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0]; // Only receiving one image, so .[0] is fine
                    var imgBytes = new Byte[file.ContentLength];
                    var imgBytesLength = imgBytes.Length;
                    file.InputStream.Read(imgBytes, 0, imgBytesLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytesLength);
                    product.Photo = base64String;
                }
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return Redirect("Create");
            }
        }

        public ActionResult Edit(long id)
        {
            UNSCdbContext db = new UNSCdbContext();
            Product product = db.Products.Where(x => x.ID == id).FirstOrDefault();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {

                UNSCdbContext db = new UNSCdbContext();
                Product existing = db.Products.Where(x => x.ID == product.ID).FirstOrDefault();
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.DOP = product.DOP;
                existing.CategoryID = product.CategoryID;
                existing.BrandID = product.BrandID;
                existing.AvailabilityStatus = product.AvailabilityStatus;
                if (Request.Files.Count >= 1 && product.Photo != null)
                {
                    var file = Request.Files[0]; // Only receiving one image, so .[0] is fine
                    var imgBytes = new Byte[file.ContentLength];
                    var imgBytesLength = imgBytes.Length;
                    file.InputStream.Read(imgBytes, 0, imgBytesLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytesLength);
                    existing.Photo = base64String;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public ActionResult Delete(long id)
        {
            UNSCdbContext db = new UNSCdbContext();
            Product product = db.Products.Where(x => x.ID == id).FirstOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}