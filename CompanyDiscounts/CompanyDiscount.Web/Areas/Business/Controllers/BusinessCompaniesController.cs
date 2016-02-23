using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using CompanyDiscount.Web.Areas.Business.Models;
using CompanyDiscount.Web.Infrastructure.Mapping;
using CompanyDiscounts.Models;
using CompanyDiscounts.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace CompanyDiscount.Web.Areas.Business.Controllers
{
    public class BusinessCompaniesController : BusinessBaseController
    {
        private readonly ICompanyBusinessesServices companyBusinesses;
        private readonly ICompaniesServices companies;
        private readonly IBusinessesServices businesses;
        private static int businessId;

        public BusinessCompaniesController(ICompanyBusinessesServices companyBusinesses, IBusinessesServices businesses, ICompaniesServices companies)
        {
            this.businesses = businesses;
            this.companyBusinesses = companyBusinesses;
            this.companies = companies;
        }

        public ActionResult Index()
        {
            ViewData["companies"] = this.companies.GetAll()
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
            DataSourceResult result = businesscompaniesviewmodels.ToDataSourceResult(request, businessCompaniesViewModel => new {
                Id = businessCompaniesViewModel.Id,
                BusinessId = businessCompaniesViewModel.BusinessId,
                Company = businessCompaniesViewModel.Company,
                Discount = businessCompaniesViewModel.Discount
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BusinessCompaniesViewModels_Create([DataSourceRequest]DataSourceRequest request, BusinessCompaniesViewModel businessCompaniesViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new BusinessCompaniesViewModel
                {
                    BusinessId = businessCompaniesViewModel.BusinessId,
                    Company = businessCompaniesViewModel.Company,
                    Discount = businessCompaniesViewModel.Discount
                };

                var businessCompanyToAdd = this.Mapper.Map<CompanyBusiness>(entity);

                this.companyBusinesses.Create(businessCompanyToAdd);
            }

            return Json(new[] { businessCompaniesViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BusinessCompaniesViewModels_Update([DataSourceRequest]DataSourceRequest request, BusinessCompaniesViewModel businessCompaniesViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new BusinessCompaniesViewModel
                {
                    Id = businessCompaniesViewModel.Id,
                    BusinessId = businessCompaniesViewModel.BusinessId,
                    Company = businessCompaniesViewModel.Company,
                    Discount = businessCompaniesViewModel.Discount
                };

                var businessCompanyToUpdate = this.Mapper.Map<CompanyBusiness>(entity);

                this.companyBusinesses.Update(businessCompanyToUpdate);
            }

            return Json(new[] { businessCompaniesViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BusinessCompaniesViewModels_Destroy([DataSourceRequest]DataSourceRequest request, BusinessCompaniesViewModel businessCompaniesViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new BusinessCompaniesViewModel
                {
                    Id = businessCompaniesViewModel.Id,
                    BusinessId = businessCompaniesViewModel.BusinessId,
                    Company = businessCompaniesViewModel.Company,
                    Discount = businessCompaniesViewModel.Discount
                };

                this.companyBusinesses.DeleteById(entity.Id);
            }

            return Json(new[] { businessCompaniesViewModel }.ToDataSourceResult(request, ModelState));
        }
    }
}
