﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
   
    public class HomeController : AdminBaseController
    {
        // GET: Administration/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}