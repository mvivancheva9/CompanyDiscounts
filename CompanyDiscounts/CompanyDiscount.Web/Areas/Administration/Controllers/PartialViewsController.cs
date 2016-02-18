using System.Threading.Tasks;
using System.Web;
using CompanyDiscount.Web.Areas.Administration.Models;
using CompanyDiscounts.Models;
using Kendo.Mvc.Extensions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using CompanyDiscounts.Services.Contracts;

    public class PartialViewsController : Controller
    {
        private readonly ICompaniesServices companies;
        private readonly IBusinessesServices businesses;
        private ApplicationUserManager userManager;
        private static int companyId;

        public PartialViewsController(ApplicationUserManager userManager)
        {
            this.UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get { return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { this.userManager = value; }
        }

        public PartialViewsController(ICompaniesServices companies, IBusinessesServices businesses)
        {
            this.companies = companies;
            this.businesses = businesses;
        }

        public ActionResult NewCompanies()
        {
            var allCompanies = this.companies.GetAll().Count();
            return PartialView(allCompanies);
        }

        public ActionResult NewBusinesses()
        {
            var allBusinesses = this.businesses.GetAll().Count();
            return PartialView(allBusinesses);
        }

        public ActionResult AddCompanyUser(int id)
        {
            companyId = id;
            if (this.companies.GetById(companyId).UserId == null)
            {
                return View();
            }
            return View("CompanyUserDetails");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddCompanyUser(CompanyUsersAddViewModel companyUsersAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CompanyUsersAddViewModel
                {
                    Email = companyUsersAddViewModel.Email,
                    Password = companyUsersAddViewModel.Password
                };

                var user = new User { UserName = entity.Email, Email = entity.Email};
                var result = await this.UserManager.CreateAsync(user, entity.Password);

                this.UserManager.AddToRole(user.Id, "Company");

                this.companies.UpdateById(companyId, user.Id);
            }

            return this.RedirectToAction("Index", "Companies");
        }
    }
}