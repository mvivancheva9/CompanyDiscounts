using System.Web.Mvc;
using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscount.Web.Areas.Business.Controllers
{
    public class BusinessDetailsController : BusinessBaseController
    {
        // GET: Business/BusinessDetails
        public ActionResult Index()
        {
            return View();
        }

        public BusinessDetailsController(IBusinessesServices businesses)
        {
        }
    }
}