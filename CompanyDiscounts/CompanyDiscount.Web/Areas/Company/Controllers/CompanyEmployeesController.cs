using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using CompanyDiscount.Web.Areas.Company.Models;
using CompanyDiscount.Web.Infrastructure.Mapping;
using CompanyDiscounts.Models;
using CompanyDiscounts.Services.Contracts;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CompanyDiscount.Web.Areas.Company.Controllers
{
    public class CompanyEmployeesController : CompanyBaseController
    {
        private readonly IEmployeesServices employees;
        private readonly ICompaniesServices companies;
        private readonly IUsersServices users;
        private ApplicationUserManager userManager;
        private static int companyId;

        public CompanyEmployeesController(ApplicationUserManager userManager)
        {
            this.UserManager = userManager;
        }

        public CompanyEmployeesController(IEmployeesServices employees, ICompaniesServices companies, IUsersServices users)
        {
            this.employees = employees;
            this.companies = companies;
            this.users = users;
        }

        public ApplicationUserManager UserManager
        {
            get { return this.userManager ?? this.HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            private set { this.userManager = value; }
        }

        public ActionResult Index()
        {
            var userId = this.User.Identity.GetUserId();
            companyId = this.companies.GetByUserId(userId).Id;
            return this.View();
        }

        public ActionResult EmployeeViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<EmployeeViewModel> employeeviewmodels = this.employees.GetAll(companyId).To<EmployeeViewModel>();
            DataSourceResult result = employeeviewmodels.ToDataSourceResult(request, employeeViewModel => new
            {
                Id = employeeViewModel.Id,
                Username = employeeViewModel.Username,
                CompanyId = employeeViewModel.CompanyId
            });

            return this.Json(result);
        }

        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(CompanyUsersAddViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new CompanyUsersAddViewModel
                {
                    Email = model.Email,
                    Password = model.Password
                };

                var user = new User { UserName = entity.Email, Email = entity.Email };
                var result = await this.UserManager.CreateAsync(user, entity.Password);

                this.UserManager.AddToRole(user.Id, "Employee");

                var newEmployee = new CompanyDiscounts.Models.Employee()
                {
                    UserId = user.Id,
                    CompanyId = companyId
                };
                this.employees.Create(newEmployee);
            }

            return this.RedirectToAction("Index");
        }
    }
}
