﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UNSCCatalogue.Web.ViewModels
{
    public class AccountLogin
    {
        [Required]
        public string Username { get; set; }
        
        [Required] 
        public string Password { get; set; }
    }
}