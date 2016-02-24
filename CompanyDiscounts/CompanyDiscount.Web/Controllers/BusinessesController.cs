using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyDiscount.Web.Areas.Business.Models;
using CompanyDiscount.Web.Infrastructure.Mapping;
using CompanyDiscount.Web.Models;
using CompanyDiscounts.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace CompanyDiscount.Web.Controllers
{
    public class BusinessesController : BaseController
    {
        private readonly IBusinessesServices businesses;
        private readonly ICompanyBusinessesServices companyBusinesses;
        private readonly IEmployeesServices employeeServices;

        public BusinessesController(IBusinessesServices businesses, ICompanyBusinessesServices companyBusinesses, IEmployeesServices employeeServices)
        {
            this.businesses = businesses;
            this.companyBusinesses = companyBusinesses;
            this.employeeServices = employeeServices;
        }
        // GET: Companies
        public ActionResult Index()
        {
            if (this.User.IsInRole("Employee"))
            {
                var userId = this.User.Identity.GetUserId();
                var currentCompaniesId = this.employeeServices.GetByUserId(userId).CompanyId;
                var currentCompanyBusinesses = this.companyBusinesses.GetByCompanyId(currentCompaniesId);

                var list = currentCompanyBusinesses.To<BusinessDetailsLocationsViewModel>();
                var employeeViewModel = new BusinessListViewModel
                {
                    Businesses = list
                };

                return this.View(employeeViewModel);
            }
            var businessList = this.businesses.GetAll().To<BusinessDetailsLocationsViewModel>().ToList();
            var viewModel = new BusinessListViewModel
            {
                Businesses = businessList
            };

            return this.View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var business = this.businesses.GetById(id);
            var viewModel = this.Mapper.Map<BusinessDetailsLocationsViewModel>(business);
            return this.View(viewModel);
        }
    }
}