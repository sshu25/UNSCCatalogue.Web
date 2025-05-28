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
    }
}