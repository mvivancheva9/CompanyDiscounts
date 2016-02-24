using System.Threading.Tasks;
using System.Web;
using CompanyDiscount.Web.Areas.Administration.Models;
using CompanyDiscount.Web.Controllers;
using CompanyDiscounts.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using CompanyDiscounts.Services.Contracts;

    public class PartialViewsController : BaseController
    {
        private static int companyId;
        private static int businessId;
        private readonly ICategoriesServices categories;
        private readonly ICompaniesServices companies;
        private readonly IUsersServices users;
        private readonly IBusinessesServices businesses;
        private ApplicationUserManager userManager;

        public PartialViewsController(ApplicationUserManager userManager)
        {
            this.UserManager = userManager;
        }

        public PartialViewsController(ICompaniesServices companies, IBusinessesServices businesses, IUsersServices users, ICategoriesServices categories)
        {
            this.companies = companies;
            this.businesses = businesses;
            this.users = users;
            this.categories = categories;
        }

        public ApplicationUserManager UserManager
        {
            get { return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { this.userManager = value; }
        }

        public ActionResult NewCompanies()
        {
            var allCompanies = this.companies.GetAll().Count();
            return this.PartialView(allCompanies);
        }

        public ActionResult NewBusinesses()
        {
            var allBusinesses = this.businesses.GetAll().Count();
            return this.PartialView(allBusinesses);
        }

        public ActionResult AddCompanyUser(int id)
        {
            companyId = id;
            if (this.companies.GetById(companyId).UserId == null)
            {
                return this.View();
            }

            var currentCompanyUser = this.companies.GetById(companyId).UserId;
            var userDetails = this.users.GetById(currentCompanyUser);
            var userModel = this.Mapper.Map<CompanyUsersAddViewModel>(userDetails);
            return this.View("CompanyUserDetails", userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddCompanyUser(CompanyUsersAddViewModel companyUsersAddViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new CompanyUsersAddViewModel
                {
                    Email = companyUsersAddViewModel.Email,
                    Password = companyUsersAddViewModel.Password
                };

                var user = new User { UserName = entity.Email, Email = entity.Email };
                var result = await this.UserManager.CreateAsync(user, entity.Password);

                this.UserManager.AddToRole(user.Id, "Company");

                this.companies.UpdateById(companyId, user.Id);
            }

            return this.RedirectToAction("Index", "Companies");
        }

        public ActionResult AddBusinessUser(int id)
        {
            businessId = id;
            if (this.businesses.GetById(businessId).UserId == null)
            {
                return this.View();
            }

            var currentBusinessUser = this.businesses.GetById(businessId).UserId;
            var userDetails = this.users.GetById(currentBusinessUser);
            var userModel = this.Mapper.Map<BusinessUserViewModel>(userDetails);
            return this.View("BusinessUserDetails", userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddBusinessUser(BusinessUserViewModel businessUserViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new BusinessUserViewModel
                {
                    Email = businessUserViewModel.Email,
                    Password = businessUserViewModel.Password
                };

                var user = new User { UserName = entity.Email, Email = entity.Email };
                var result = await this.UserManager.CreateAsync(user, entity.Password);

                this.UserManager.AddToRole(user.Id, "Business");

                this.businesses.UpdateById(businessId, user.Id);
            }

            return this.RedirectToAction("Index", "Businesses");
        }

        public ActionResult BusinessCategoriesEditor()
        {
            this.ViewData["categories"] = this.categories.GetAll()
                         .Select(e => new Category
                         {
                             Id = e.Id,
                             Name = e.Name
                         })
                         .OrderBy(e => e.Name);

            return this.View("../../Views/Shared/EditorTemplates/BusinessCategoriesEditor");
        }
    }
}