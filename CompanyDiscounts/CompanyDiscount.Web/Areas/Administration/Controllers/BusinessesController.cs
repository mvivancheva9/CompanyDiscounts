using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using CompanyDiscount.Web.Areas.Administration.Models;
using CompanyDiscount.Web.Infrastructure.Mapping;
using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    public class BusinessesController : Controller
    {
        private readonly IBusinessesServices businesses;
        private readonly ICategoriesServices categories;

        public BusinessesController(IBusinessesServices businesses, ICategoriesServices categories)
        {
            this.businesses = businesses;
            this.categories = categories;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult BusinessesViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<BusinessesViewModel> businessesviewmodels = this.businesses.GetAll().To<BusinessesViewModel>();
            DataSourceResult result = businessesviewmodels.ToDataSourceResult(request, businessesViewModel => new
            {
                Id = businessesViewModel.Id,
                Name = businessesViewModel.Name,
                Description = businessesViewModel.Description
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BusinessesViewModels_Create([DataSourceRequest]DataSourceRequest request, BusinessesViewModel businessesViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new BusinessesViewModel
                {
                    Name = businessesViewModel.Name,
                    Description = businessesViewModel.Description
                };

                this.businesses.Create(entity.Name, entity.Description);
                businessesViewModel.Id = entity.Id;
            }

            return this.Json(new[] { businessesViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BusinessesViewModels_Update([DataSourceRequest]DataSourceRequest request, BusinessesViewModel businessesViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new BusinessesViewModel
                {
                    Id = businessesViewModel.Id,
                    Name = businessesViewModel.Name,
                    Description = businessesViewModel.Description
                };
                this.businesses.UpdateById(entity.Id, entity.Name, entity.Description);
            }

            return this.Json(new[] { businessesViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BusinessesViewModels_Destroy([DataSourceRequest]DataSourceRequest request, BusinessesViewModel businessesViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new BusinessesViewModel
                {
                    Id = businessesViewModel.Id,
                    Name = businessesViewModel.Name,
                    Description = businessesViewModel.Description
                };

                this.businesses.DeleteById(entity.Id);
            }

            return this.Json(new[] { businessesViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
