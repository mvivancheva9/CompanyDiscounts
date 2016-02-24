using System.Linq;
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
    public class BusinessLocationsController : BusinessBaseController
    {
        private static string userId;
        private readonly IBusinessLocationsServices businessLocations;
        private readonly IBusinessesServices businesses;
        private int businessId;

        public BusinessLocationsController(IBusinessLocationsServices businessLocations, IBusinessesServices businesses)
        {
            this.businessLocations = businessLocations;
            this.businesses = businesses;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult BusinessLocationsViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            userId = this.User.Identity.GetUserId();
            this.businessId = this.businesses.GetByUserId(userId).Id;
            IQueryable<BusinessLocationsViewModel> businesslocationsviewmodels = this.businessLocations.GetAll(this.businessId).To<BusinessLocationsViewModel>();
            DataSourceResult result = businesslocationsviewmodels.ToDataSourceResult(request, businessLocationsViewModel => new
            {
                Id = businessLocationsViewModel.Id,
                Longitude = businessLocationsViewModel.Longitude,
                Latitude = businessLocationsViewModel.Latitude,
                BusinessId = businessLocationsViewModel.BusinessId
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BusinessLocationsViewModels_Create([DataSourceRequest]DataSourceRequest request, BusinessLocationsViewModel businessLocationsViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new BusinessLocation()
                {
                    Longitude = businessLocationsViewModel.Longitude,
                    Latitude = businessLocationsViewModel.Latitude,
                    BusinessId = businessLocationsViewModel.BusinessId
                };
                this.businessLocations.Create(entity);
            }

            return this.Json(new[] { businessLocationsViewModel }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult BusinessLocationsViewModels_Destroy([DataSourceRequest]DataSourceRequest request, BusinessLocationsViewModel businessLocationsViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new BusinessLocation()
                {
                    Id = businessLocationsViewModel.Id,
                    Longitude = businessLocationsViewModel.Longitude,
                    Latitude = businessLocationsViewModel.Latitude,
                    BusinessId = businessLocationsViewModel.BusinessId
                };

                this.businessLocations.DeleteById(entity.Id);
            }

            return this.Json(new[] { businessLocationsViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
