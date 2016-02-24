namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Models;
    using Infrastructure.Mapping;
    using CompanyDiscounts.Services.Contracts;

    public class DeleteCompaniesController : Controller
    {
        private readonly ICompaniesServices companies;

        public DeleteCompaniesController(ICompaniesServices companies)
        {
            this.companies = companies;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult CompaniesViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<DeletedCompaniesViewModel> companiesviewmodels = this.companies.GetDeleted().To<DeletedCompaniesViewModel>();
            DataSourceResult result = companiesviewmodels.ToDataSourceResult(request, companiesViewModel => new
            {
                Id = companiesViewModel.Id,
                Name = companiesViewModel.Name,
                Description = companiesViewModel.Description,
                IsDeleted = companiesViewModel.IsDeleted
            });

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompaniesViewModels_Update([DataSourceRequest]DataSourceRequest request, DeletedCompaniesViewModel companiesViewModel)
        {
            if (this.ModelState.IsValid)
            {
                var entity = new DeletedCompaniesViewModel
                {
                    Id = companiesViewModel.Id,
                    Name = companiesViewModel.Name,
                    Description = companiesViewModel.Description,
                    IsDeleted = companiesViewModel.IsDeleted
                };

                this.companies.UpdateDeletedById(entity.Id, entity.Name, entity.Description, entity.IsDeleted);
            }

            return this.Json(new[] { companiesViewModel }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
