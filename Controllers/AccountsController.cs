using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNSCCatalogue.Web.Models;
using UNSCCatalogue.Web.ViewModels;
using UNSCCatalogue.Web.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.UI.WebControls;

namespace UNSCCatalogue.Web.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AccountCreate account)
        {
            if (ModelState.IsValid)
            {
                var identityDB = new IdentitydbContext();
                var userStore = new UserStore(identityDB);
                var userManager = new UserManager(userStore);
                
                var pwHash = Crypto.HashPassword(account.Password);
                var user = new User()
                {
                    Email = account.Email,
                    UserName = account.Username,
                    PasswordHash = pwHash,
                    City = account.City,
                    Country = account.Country,
                    Birthday = account.DateOfBirth,
                    Address = account.Address,
                    PhoneNumber = account.Mobile
                };

                IdentityResult result = userManager.Create(user);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authManager.SignIn(new AuthenticationProperties(), userIdentity);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Error", "ModelState invalid");
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountLogin login)
        {
            var identityDB = new IdentitydbContext();
            var userStore = new UserStore(identityDB);
            var userManager = new UserManager(userStore);
            var user = userManager.Find(login.Username, login.Password);

            if (user != null)
            {
                // Login
                var authManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties(), userIdentity);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("Error", "Invalid username or password");
                return View();
            }
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Accounts");
        }
    }
}