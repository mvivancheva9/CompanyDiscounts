using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscount.Web.Areas.Business.Controllers
{
    public class BusinessLocationsController : BusinessBaseController
    {
        // GET: Business/BusinessLocations
        public ActionResult Index()
        {
            var currentBusiness = this.CurrentBusiness();
            return View();
        }

        public BusinessLocationsController(IBusinessesServices businesses) : base(businesses)
        {

        }
    }
}