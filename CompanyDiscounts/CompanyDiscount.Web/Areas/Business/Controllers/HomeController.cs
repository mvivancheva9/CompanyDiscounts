using System.Linq;
using System.Web.Mvc;
using CompanyDiscount.Web.Areas.Business.Models;
using CompanyDiscounts.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace CompanyDiscount.Web.Areas.Business.Controllers
{
    public class HomeController : BusinessBaseController
    {
        private readonly IBusinessesServices businesses;
        private readonly ICategoriesServices categories;

        public HomeController(IBusinessesServices businesses, ICategoriesServices categories)
        {
            this.businesses = businesses;
            this.categories = categories;
        }

        // GET: Business/Home
        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            var business = this.businesses.GetByUserId(userId);
            var viewModel = this.Mapper.Map<BusinessDetailsViewModel>(business);

            return this.View(viewModel);
        }

        public ActionResult Manage()
        {
            ViewData["categories"] = this.categories.GetAll()
                .Select(e => new CategoryViewModel
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .OrderBy(e => e.Name);

            return View();
        }
    }
}