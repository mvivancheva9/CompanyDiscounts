using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using CompanyDiscount.Web.Areas.Administration.Models;
﻿using CompanyDiscount.Web.Infrastructure.Mapping;
﻿using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    public class DeletedBusinessesController : Controller
    {
        private readonly IBusinessesServices businesses;

        public DeletedBusinessesController(IBusinessesServices businesses)
        {
            this.businesses = businesses;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DeletedBusinessesViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<DeletedBusinessesViewModel> deletedbusinessesviewmodels = this.businesses.GetDeleted().To<DeletedBusinessesViewModel>();
            DataSourceResult result = deletedbusinessesviewmodels.ToDataSourceResult(request, deletedBusinessesViewModel => new {
                Id = deletedBusinessesViewModel.Id,
                Name = deletedBusinessesViewModel.Name,
                Description = deletedBusinessesViewModel.Description,
                IsDeleted = deletedBusinessesViewModel.IsDeleted
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeletedBusinessesViewModels_Update([DataSourceRequest]DataSourceRequest request, DeletedBusinessesViewModel deletedBusinessesViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new DeletedBusinessesViewModel
                {
                    Id = deletedBusinessesViewModel.Id,
                    Name = deletedBusinessesViewModel.Name,
                    Description = deletedBusinessesViewModel.Description,
                    IsDeleted = deletedBusinessesViewModel.IsDeleted
                };
                this.businesses.UpdateDeletedById(entity.Id, entity.Name, entity.Description, entity.IsDeleted);
            }

            return Json(new[] { deletedBusinessesViewModel }.ToDataSourceResult(request, ModelState));
        }
    }
}
