using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UNSCCatalogue.Web.Models
{
    public partial class Product
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> DateOfPurchase { get; set; }
        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> BrandID { get; set; }
        public bool AvailabilityStatus { get; set; }
        public string Photo { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
