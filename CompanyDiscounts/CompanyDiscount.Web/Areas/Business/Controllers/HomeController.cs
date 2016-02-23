using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscount.Web.Areas.Business.Controllers
{
    public class HomeController : BusinessBaseController
    {
        // GET: Business/Home
        public ActionResult Index()
        {
            return View();
        }

        public HomeController(IBusinessesServices businesses)
        {
        }
    }
}