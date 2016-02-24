using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using CompanyDiscount.Web.Areas.Business.Models;
﻿using CompanyDiscount.Web.Infrastructure.Mapping;
﻿using CompanyDiscounts.Models;
﻿using CompanyDiscounts.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace CompanyDiscount.Web.Areas.Business.Controllers
{
    public class BusinessCompaniesController : BusinessBaseController
    {
        private static int businessId;
        private readonly ICompanyBusinessesServices companyBusinesses;
        private readonly IBusinessesServices businesses;
        private readonly ICompaniesServices companies;

        public BusinessCompaniesController(IBusinessesServices businesses, ICompanyBusinessesServices companyBusinesses, ICompaniesServices companies)
        {
            this.companyBusinesses = companyBusinesses;
            this.businesses = businesses;
            this.companies = companies;
        }

        public ActionResult Index()
        {
            this.ViewData["companies"] = this.companies.GetAll()
                 .Select(e => new CompanyViewModel
                 {
                     Id = e.Id,
                     Name = e.Name
                 })
                 .OrderBy(e => e.Name);
            return this.View();
        }

        public ActionResult BusinessCompaniesViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            var userId = this.User.Identity.GetUserId();
            businessId = this.businesses.GetByUserId(userId).Id;
            IQueryable<BusinessCompaniesViewModel> businesscompaniesviewmodels = this.companyBusinesses.GetAll(businessId).To<BusinessCompaniesViewModel>();
            DataSourceResult result = businesscompaniesviewmodels.ToDataSourceResult(request, businessCompaniesViewModel => new
            {
                Id = businessCompaniesViewModel.Id,
                BusinessId = businessCompaniesViewModel.BusinessId,
                Discount = businessCompaniesViewModel.Discount,
                Company = businessCompaniesViewModel.Company
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BusinessCompaniesViewModels_Update([DataSourceRequest]DataSourceRequest request, BusinessCompaniesViewModel businessCompaniesViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new CompanyBusiness()
                {
                    Id = businessCompaniesViewModel.Id,
                    BusinessId = businessId,
                    CompanyId = businessCompaniesViewModel.Company.Id,
                    Discount = businessCompaniesViewModel.Discount
                };

                this.companyBusinesses.Update(entity);
            }

            return this.Json(new[] { businessCompaniesViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BusinessCompaniesViewModels_Destroy([DataSourceRequest]DataSourceRequest request, BusinessCompaniesViewModel businessCompaniesViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new BusinessCompaniesViewModel
                {
                    Id = businessCompaniesViewModel.Id,
                    BusinessId = businessCompaniesViewModel.BusinessId,
                    Discount = businessCompaniesViewModel.Discount
                };

                this.companyBusinesses.DeleteById(entity.Id);
            }

            return this.Json(new[] { businessCompaniesViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpGet]
        public ActionResult Add()
        {
            this.ViewData["companies"] = this.companies.GetAll()
                  .Select(e => new CompanyViewModel
                  {
                      Id = e.Id,
                      Name = e.Name
                  })
                  .OrderBy(e => e.Name);
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(BusinessCompaniesViewModel model)
        {
            var newBusinessCompany = new CompanyBusiness()
            {
                CompanyId = model.Company.Id,
                Discount = model.Discount,
                BusinessId = businessId
            };
            this.companyBusinesses.Create(newBusinessCompany);

            return this.RedirectToAction("Index");
        }
    }
}
