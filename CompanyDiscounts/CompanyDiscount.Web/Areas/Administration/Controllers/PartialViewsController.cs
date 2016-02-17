using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    public class PartialViewsController : Controller
    {
        private readonly ICompaniesServices companies;
        private readonly IBusinessesServices businesses;

        public PartialViewsController(ICompaniesServices companies, IBusinessesServices businesses)
        {
            this.companies = companies;
            this.businesses = businesses;
        }

        public ActionResult NewCompanies()
        {
            var allCompanies = this.companies.GetAll().Count();
            return PartialView(allCompanies);
        }

        public ActionResult NewBusinesses()
        {
            var allBusinesses = this.businesses.GetAll().Count();
            return PartialView(allBusinesses);
        }
    }
}