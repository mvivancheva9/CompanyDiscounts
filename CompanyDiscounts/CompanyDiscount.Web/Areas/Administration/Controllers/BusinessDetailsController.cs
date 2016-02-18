using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyDiscount.Web.Areas.Administration.Models;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    public class BusinessDetailsController : Controller
    {
        private static BusinessesViewModel currentBusiness;

        // GET: Administration/CategoryDetails
        public void Load(BusinessesViewModel business)
        {
            currentBusiness = business;
        }

        public ActionResult Index()
        {
            return this.View(currentBusiness);
        }
    }
}