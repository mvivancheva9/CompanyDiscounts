using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyDiscount.Web.Controllers;
using CompanyDiscount.Web.ViewModels.Companies;
using CompanyDiscounts.Services.Contracts;
using Ninject;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    public class HomeController : BaseController
    {
        [Inject]
        private readonly ICompaniesServices companies;

        public HomeController(ICompaniesServices companies)
        {
            this.companies = companies;
        }
       
        [HttpGet]
        public ActionResult Index()
        {
            var company = this.companies.GetAll().FirstOrDefault();

            var viewModel = new CompanyDetailsViewModel()
            {
                Name = company.Name,
                Description = company.Description
            };

            return this.View(viewModel);
        }
    }
}