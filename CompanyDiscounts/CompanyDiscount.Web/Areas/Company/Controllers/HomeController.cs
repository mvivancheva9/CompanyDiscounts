using System.Linq;
using System.Web.Mvc;
using CompanyDiscount.Web.Controllers;
using CompanyDiscount.Web.ViewModels.Companies;
using CompanyDiscounts.Services.Contracts;
using Microsoft.AspNet.Identity;
using Ninject;

namespace CompanyDiscount.Web.Areas.Company.Controllers
{
    public class HomeController : BaseController
    {
        [Inject]
        private readonly ICompaniesServices companies;

        public HomeController(ICompaniesServices companies)
        {
            this.companies = companies;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var company = this.companies.GetAll().FirstOrDefault();

            var viewModel = new CompanyDetailsViewModel()
            {
                Name = company.Name,
                Description = company.Description
            };

            return this.View(viewModel);
        }

        public ActionResult Manage()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(CompanyDetailsViewModel model)
        {
            var userId = this.User.Identity.GetUserId();
            var business = this.companies.GetByUserId(userId);
            model.Id = business.Id;
            var businessToUpdate = new CompanyDiscounts.Models.Company()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description
            };
            this.companies.Update(businessToUpdate);
            return this.RedirectToAction("Index");
        }

        public ActionResult PageNotFound()
        {
            this.ViewBag.Message = "Sorry, the page you requested does not exist.";
            return this.View("Index");
        }
    }
}