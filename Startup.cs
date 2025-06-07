using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using UNSCCatalogue.Web.Models;
using UNSCCatalogue.Web.Identity;

[assembly: OwinStartup(typeof(UNSCCatalogue.Web.Startup))]

namespace UNSCCatalogue.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.UseCookieAuthentication(new CookieAuthenticationOptions() { AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, LoginPath = new PathString(("/Account/Login")) });
            this.CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            var db = new IdentitydbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db)); // Need to explicitly tell RoleManager to point to db, otherwise will try and point to "default connection"
            var userStore = new UserStore(db);
            var userManager = new UserManager(userStore);


            var adminExists = roleManager.RoleExists("Admin");
            // Create Admin Role
            if (!adminExists)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            // Create Admin User
            if (userManager.FindByName("Admin") == null)
            {
                var user = new User();
                user.UserName = "Admin";
                user.Email = "admin@gmail.com";
                string pw = "admin123";

                var checkUser = userManager.Create(user, pw);
                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }

            var managerExists = roleManager.RoleExists("Manager");
            // Create Manager Role
            if (!managerExists)
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }
            // Create Manager User
            if (userManager.FindByName("Manager") == null)
            {
                var user = new User();
                user.UserName = "Manager";
                user.Email = "manager@gmail.com";
                string pw = "manager123";
                
                var checkUser = userManager.Create(user, pw);
                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Manager");
                }
            }

            // Create Customer Role
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
            // Create Customer User
            if (userManager.FindByName("Customer") == null)
            {
                var user = new User();
                user.UserName = "Customer";
                user.Email = "customer@gmail.com";
                string pw = "customer123";

                var checkUser = userManager.Create(user, pw);
                if (checkUser.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                }
            }
        }
    }
}
