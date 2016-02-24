using System.Web.Mvc;

namespace CompanyDiscount.Web.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Company/Error
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult NotFound()
        {
            return this.View();
        }

        public ActionResult BadRequest()
        {
            return this.View();
        }
    }
}