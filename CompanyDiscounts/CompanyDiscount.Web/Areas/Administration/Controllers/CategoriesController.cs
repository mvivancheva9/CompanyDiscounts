namespace CompanyDiscount.Web.Areas.Administration.Controllers
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
            return this.View();
        }

        public ActionResult CategoriesViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<CategoriesViewModel> categoriesviewmodels = this.cateogries.GetAll().To<CategoriesViewModel>();
            DataSourceResult result = categoriesviewmodels.ToDataSourceResult(request, categoriesViewModel => new
            {
                Id = categoriesViewModel.Id,
                Name = categoriesViewModel.Name,
                IsDeleted = categoriesViewModel.IsDeleted
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CategoriesViewModels_Create([DataSourceRequest]DataSourceRequest request, CategoriesViewModel categoriesViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new CategoriesViewModel
                {
                    Name = categoriesViewModel.Name
                };

                this.cateogries.Create(entity.Name);
                categoriesViewModel.Id = entity.Id;
            }

            return this.Json(new[] { categoriesViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CategoriesViewModels_Update([DataSourceRequest]DataSourceRequest request, CategoriesViewModel categoriesViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new CategoriesViewModel
                {
                    Id = categoriesViewModel.Id,
                    Name = categoriesViewModel.Name,
                    IsDeleted = categoriesViewModel.IsDeleted
                };

                this.cateogries.UpdateById(entity.Id, entity.Name, entity.IsDeleted);
            }

            return this.Json(new[] { categoriesViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CategoriesViewModels_Destroy([DataSourceRequest]DataSourceRequest request, CategoriesViewModel categoriesViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new CategoriesViewModel
                {
                    Id = categoriesViewModel.Id,
                    Name = categoriesViewModel.Name
                };

                this.cateogries.DeleteById(entity.Id);
            }

            return this.Json(new[] { categoriesViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
