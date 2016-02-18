﻿namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Web.Controllers;
    using Infrastructure.Mapping;
    using CompanyDiscounts.Services.Contracts;

    public class CategoriesController : BaseController
    {
        private readonly ICategoriesServices cateogries;

        public CategoriesController(ICategoriesServices categories)
        {
            this.cateogries = categories;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoriesViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<CategoriesViewModel> categoriesviewmodels = this.cateogries.GetAll().To<CategoriesViewModel>();
            DataSourceResult result = categoriesviewmodels.ToDataSourceResult(request, categoriesViewModel => new {
                Id = categoriesViewModel.Id,
                Name = categoriesViewModel.Name,
                IsDeleted = categoriesViewModel.IsDeleted
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CategoriesViewModels_Create([DataSourceRequest]DataSourceRequest request, CategoriesViewModel categoriesViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CategoriesViewModel
                {
                    Name = categoriesViewModel.Name
                };

                this.cateogries.Create(entity.Name);
                categoriesViewModel.Id = entity.Id;
            }

            return Json(new[] { categoriesViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CategoriesViewModels_Update([DataSourceRequest]DataSourceRequest request, CategoriesViewModel categoriesViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CategoriesViewModel
                {
                    Id = categoriesViewModel.Id,
                    Name = categoriesViewModel.Name,
                    IsDeleted = categoriesViewModel.IsDeleted
                };

                this.cateogries.UpdateById(entity.Id, entity.Name, entity.IsDeleted);
            }

            return Json(new[] { categoriesViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CategoriesViewModels_Destroy([DataSourceRequest]DataSourceRequest request, CategoriesViewModel categoriesViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CategoriesViewModel
                {
                    Id = categoriesViewModel.Id,
                    Name = categoriesViewModel.Name
                };

                this.cateogries.DeleteById(entity.Id);
            }

            return Json(new[] { categoriesViewModel }.ToDataSourceResult(request, ModelState));
        }
    }
}
