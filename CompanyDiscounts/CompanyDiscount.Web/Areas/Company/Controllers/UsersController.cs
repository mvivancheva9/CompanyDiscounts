namespace CompanyDiscount.Web.Areas.Company.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Company.Models;
    using Web.Controllers;
    using Infrastructure.Mapping;
    using CompanyDiscounts.Models;
    using CompanyDiscounts.Services.Contracts;
    using Microsoft.AspNet.Identity.Owin;

    public class UsersController : BaseController
    {
        private readonly IUsersServices users;
        private ApplicationUserManager userManager;

        public UsersController(IUsersServices users)
        {
            this.users = users;
        }

        public UsersController(ApplicationUserManager userManager)
        {
            this.UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get { return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { this.userManager = value; }
        }

        public ActionResult Index()
        {
            var allUSers = this.users.GetAll();
            return View();
        }

        public ActionResult CompanyUsersViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            var usersFromDb = this.users.GetAll();
            IQueryable<CompanyUsersAddViewModel> companyusersviewmodels = usersFromDb.To<CompanyUsersAddViewModel>();
            DataSourceResult result = companyusersviewmodels.ToDataSourceResult(request, companyUsersViewModel => new {

                Email = companyUsersViewModel.Email
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyUsersViewModels_Create([DataSourceRequest]DataSourceRequest request, CompanyUsersAddViewModel companyUsersAddViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CompanyUsersAddViewModel
                {
                    Email = companyUsersAddViewModel.Email,
                    Password = companyUsersAddViewModel.Password
                };

                var user = new User { UserName = entity.Email, Email = entity.Email };
                var result = this.UserManager.CreateAsync(user, entity.Password);
                companyUsersAddViewModel.Id = entity.Id;
            }

            return Json(new[] { companyUsersAddViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyUsersViewModels_Update([DataSourceRequest]DataSourceRequest request, CompanyUsersAddViewModel companyUsersViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CompanyUsersAddViewModel
                {
                    Email = companyUsersViewModel.Email,
                    Password = companyUsersViewModel.Password
                };

                this.users.Update(this.Mapper.Map<User>(entity));
            }

            return Json(new[] { companyUsersViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyUsersViewModels_Destroy([DataSourceRequest]DataSourceRequest request, CompanyUsersAddViewModel companyUsersViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CompanyUsersAddViewModel
                {
                    Email = companyUsersViewModel.Email
                };

                this.users.DeleteById(entity.Email);
            }

            return Json(new[] { companyUsersViewModel }.ToDataSourceResult(request, ModelState));
        }
    }
}
