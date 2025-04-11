using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNSCCatalogue.Web.Models;

namespace UNSCCatalogue.Web.Controllers
{
    public class CategoriesController : Controller
    {
        public ActionResult Index()
        {
            UNSCdbEntities db = new UNSCdbEntities();
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}