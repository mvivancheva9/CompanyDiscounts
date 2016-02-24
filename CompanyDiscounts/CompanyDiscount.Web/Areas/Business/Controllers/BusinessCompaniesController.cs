﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
﻿using CompanyDiscount.Web.Areas.Administration.Models;
﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using CompanyDiscount.Web.Areas.Business.Models;
﻿using CompanyDiscount.Web.Infrastructure.Mapping;
﻿using CompanyDiscounts.Models;
﻿using CompanyDiscounts.Services.Contracts;
﻿using Microsoft.Ajax.Utilities;
﻿using Microsoft.AspNet.Identity;

namespace CompanyDiscount.Web.Areas.Business.Controllers
{
    public class BusinessCompaniesController : BusinessBaseController
    {
        private readonly ICompanyBusinessesServices companyBusinesses;
        private readonly IBusinessesServices businesses;
        private readonly ICompaniesServices companies;
        private static int businessId;


        public BusinessCompaniesController(IBusinessesServices businesses, ICompanyBusinessesServices companyBusinesses, ICompaniesServices companies)
        {
            this.companyBusinesses = companyBusinesses;
            this.businesses = businesses;
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
                Discount = businessCompaniesViewModel.Discount,
                Company = businessCompaniesViewModel.Company
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BusinessCompaniesViewModels_Update([DataSourceRequest]DataSourceRequest request, BusinessCompaniesViewModel businessCompaniesViewModel)
        {
            if (ModelState.IsValid)
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
                    Discount = businessCompaniesViewModel.Discount
                };

                this.companyBusinesses.DeleteById(entity.Id);
            }

            return Json(new[] { businessCompaniesViewModel }.ToDataSourceResult(request, ModelState));
        }

        [HttpGet]
        public ActionResult Add()
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
