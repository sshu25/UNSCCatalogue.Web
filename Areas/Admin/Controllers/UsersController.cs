using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNSCCatalogue.Web.Identity;
using UNSCCatalogue.Web.Models;

namespace UNSCCatalogue.Web.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: Admin/Users
        public ActionResult Index()
        {
            IdentitydbContext db = new IdentitydbContext();
            List<User> users = db.Users.ToList();
            return View(users);
        }
    }
}