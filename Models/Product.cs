﻿using System;
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
        [Key]
        [Display(Name = "ID")]
        public long ID { get; set; }

        [Required]
        [Display(Name = "Name")]
        [RegularExpression(@"^[A-Za-z\d-. ]*$", ErrorMessage = "Name can only be alphanumeric characters, hyphens, or periods")]
        [MinLength(1, ErrorMessage = "Name must be between 1-40 characters")]
        [MaxLength(40, ErrorMessage = "Name must be between 1-40 characters")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be between more than 0")]
        public Nullable<decimal> Price { get; set; }

        [Display(Name = "Date Of Purchase")]
        [Column("DateOfPurchase", TypeName ="datetime")]
        public Nullable<System.DateTime> DOP { get; set; }

        [Required(ErrorMessage = "The Category field is required")]
        [Display(Name = "Category ID")]
        public long CategoryID { get; set; }

        [Required(ErrorMessage = "The Brand field is required")]
        [Display(Name = "Brand ID")]
        public long BrandID { get; set; }

        [Display(Name = "Availability Status")]
        public bool AvailabilityStatus { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}
