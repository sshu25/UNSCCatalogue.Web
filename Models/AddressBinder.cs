using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace UNSCCatalogue.Web.Models
{
    public class AddressBinder : System.Web.Mvc.IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            int ID = Convert.ToInt32(controllerContext.HttpContext.Request.Form["ID"]);
            string Name = controllerContext.HttpContext.Request.Form["Name"];
            string StreetNumber = controllerContext.HttpContext.Request.Form["StreetNumber"];
            string StreetName = controllerContext.HttpContext.Request.Form["StreetName"];
            string City = controllerContext.HttpContext.Request.Form["City"];
            string Planet = controllerContext.HttpContext.Request.Form["Planet"];

            return new Account()
            {
                ID = ID,
                Name = Name,
                Address = StreetNumber + " " + StreetName + ", " + City + ", " + Planet
            };
        }
    }
}