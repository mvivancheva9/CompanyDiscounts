using System.Linq;
using System.Web.Mvc;
using CompanyDiscount.Web.Areas.Business.Models;
using CompanyDiscounts.Models;
using CompanyDiscounts.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace CompanyDiscount.Web.Areas.Business.Controllers
{
    public class AddBusinessLocationsController : BusinessBaseController
    {
        private static int businessId;
        private readonly IBusinessLocationsServices businessLocations;
        private readonly IBusinessesServices businesses;

        public AddBusinessLocationsController(IBusinessLocationsServices businessLocations, IBusinessesServices businesses)
        {
            this.businessLocations = businessLocations;
            this.businesses = businesses;
        }

        // GET: Business/AddBusinessLocations
        public ActionResult Index()
        {
            string userId = this.User.Identity.GetUserId();
            var currentBusiness = this.businesses.GetAll().FirstOrDefault(b => b.UserId == userId);
            if (currentBusiness != null)
            {
                businessId = currentBusiness.Id;
            }

            return this.View();
        }

        [HttpPost]
        public void Add(PinViewModel[] pins)
        {
            var businessPins = pins;

            foreach (var pin in businessPins)
            {
                var latitude = pin.Latitude;
                var longitude = pin.Longitude;

                var newBusinessLocation = new BusinessLocation()
                {
                    Latitude = latitude,
                    Longitude = longitude,
                    BusinessId = businessId
                };

                this.businessLocations.Create(newBusinessLocation);
            }
        }
    }
}