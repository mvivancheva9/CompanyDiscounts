using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyDiscount.Web.Areas.Administration.Models;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    public class CompanyDetailsController : Controller
    {
        private static CompaniesViewModel currentCompany;

        // GET: Administration/CategoryDetails
        public void Load(CompaniesViewModel company)
        {
            currentCompany = company;
        }

        public ActionResult Index()
        {
            return this.View(currentCompany);
        }
    }
}