﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UNSCCatalogue.Web.Models;

namespace UNSCCatalogue.Web.Controllers
{
    public class AccountsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(AddressBinder))] Account account)
        {
            return View();
        }
    }
}