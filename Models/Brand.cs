using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UNSCCatalogue.Web.Models
{
    public partial class Brand
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
    }
}
