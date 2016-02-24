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
    public class BusinessesController : Controller
    {
        private readonly IBusinessesServices businesses;

        public BusinessesController(IBusinessesServices businesses)
        {
            this.businesses = businesses;
        }
        // GET: Companies
        public ActionResult Index()
        {
            var businessList = this.businesses.GetAll().To<BusinessDetailsViewModel>().ToList();
            var viewModel = new BusinessListViewModel
            {
                Businesses = businessList
            };

            return this.View(viewModel);
        }
    }
}