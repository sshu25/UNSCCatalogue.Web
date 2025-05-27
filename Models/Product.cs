using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UNSCCatalogue.Web.Models
{
    [Table("Products")]
    public partial class Product
    {
        [Key, Display(Name = "ID")]
        public long ID { get; set; }

        [Required, Display(Name = "Name")]
        public string Name { get; set; }

        [Required, Display(Name = "Price")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Date Of Purchase"), Column("DateOfPurchase", TypeName ="datetime")]
        public Nullable<System.DateTime> DOP { get; set; }

        [Required, Display(Name = "Category ID")]
        public Nullable<long> CategoryID { get; set; }

        [Required, Display(Name = "Brand ID")]
        public Nullable<long> BrandID { get; set; }

        [Display(Name = "Availability Status")]
        public bool AvailabilityStatus { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
