using System.Linq;
using System.Web.Mvc;
﻿using CompanyDiscount.Web.Areas.Administration.Models;
﻿using CompanyDiscount.Web.Infrastructure.Mapping;
﻿using CompanyDiscount.Web.ViewModels.Companies;
﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
﻿using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ICompaniesServices companies;

        public CompaniesController(ICompaniesServices companies)
        {
            this.companies = companies;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CompanyDetailsViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<CompaniesViewModel> companydetailsviewmodels = this.companies.GetAll().To<CompaniesViewModel>();
            DataSourceResult result = companydetailsviewmodels.ToDataSourceResult(request, companyDetailsViewModel => new {
                Id = companyDetailsViewModel.Id,
                Name = companyDetailsViewModel.Name,
                Description = companyDetailsViewModel.Description
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyDetailsViewModels_Create([DataSourceRequest]DataSourceRequest request, CompaniesViewModel companyDetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CompanyDetailsViewModel
                {
                    Name = companyDetailsViewModel.Name,
                    Description = companyDetailsViewModel.Description
                };

                this.companies.Create(entity.Name, entity.Description);
                companyDetailsViewModel.Id = entity.Id;
            }

            return Json(new[] { companyDetailsViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyDetailsViewModels_Update([DataSourceRequest]DataSourceRequest request, CompaniesViewModel companyDetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CompaniesViewModel
                {
                    Name = companyDetailsViewModel.Name,
                    Description = companyDetailsViewModel.Description
                };
                entity.Id = companyDetailsViewModel.Id;
                this.companies.UpdateById(entity.Id, entity.Name, entity.Description);
            }

            return Json(new[] { companyDetailsViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyDetailsViewModels_Destroy([DataSourceRequest]DataSourceRequest request, CompaniesViewModel companyDetailsViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CompaniesViewModel
                {
                    Id = companyDetailsViewModel.Id,
                    Name = companyDetailsViewModel.Name,
                    Description = companyDetailsViewModel.Description
                };

                this.companies.DeleteById(entity.Id);
            }

            return Json(new[] { companyDetailsViewModel }.ToDataSourceResult(request, ModelState));
        }
    }
}
