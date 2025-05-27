using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace UNSCCatalogue.Web.Models
{
    public class UNSCdbContext : DbContext
    {
        public UNSCdbContext() : base("UNSCdb")
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}