using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyDiscount.Web.Areas.Business.Models;
using CompanyDiscount.Web.Infrastructure.Mapping;
using CompanyDiscount.Web.Models;
using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscount.Web.Controllers
{
    public class CompaniesController : BaseController
    {
        private readonly ICompaniesServices companies;

        public CompaniesController(ICompaniesServices companies)
        {
            this.companies = companies;
        }
        // GET: Companies
        public ActionResult Index()
        {
            var companiesList = this.companies.GetAll().To<CompanyViewModel>().ToList();
            var viewModel = new CompaniesListViewModel
            {
                Companies = companiesList
            };

            return this.View(viewModel);
        }
    }
}