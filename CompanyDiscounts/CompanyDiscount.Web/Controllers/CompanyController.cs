using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyDiscount.Web.ViewModels.Companies;
using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscount.Web.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompaniesServices companies;

        public CompanyController(ICompaniesServices companies)
        {
            this.companies = companies;
        }
        // GET: Company
        public ActionResult Index()
        {
            var company = this.companies.GetAll().FirstOrDefault();

            var viewModel = new CompanyDetailsViewModel()
            {
                Name = "Some Name",
                Description = "Some Description"
            };

            return this.View(viewModel);
        }
    }
}