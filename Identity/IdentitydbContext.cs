using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace UNSCCatalogue.Web.Identity
{
    public class IdentitydbContext : IdentityDbContext<User>
    {
        public IdentitydbContext() : base("Identitydb")
        {

        }

        //public DbSet<User> User { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().ToTable("User");
        //}
    }
}