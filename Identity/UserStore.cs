using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using UNSCCatalogue.Web.Models;

namespace UNSCCatalogue.Web.Identity
{
    public class UserStore : UserStore<User>
    {
        public UserStore(UNSCdbContext db) : base(db)
        { 
        }
    }
}