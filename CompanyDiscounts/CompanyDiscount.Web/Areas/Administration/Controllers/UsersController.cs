﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
﻿using AutoMapper;
﻿using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using CompanyDiscount.Web.Areas.Administration.Models;
﻿using CompanyDiscount.Web.Controllers;
﻿using CompanyDiscount.Web.Infrastructure.Mapping;
﻿using CompanyDiscounts.Models;
﻿using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUsersServices users;

        public UsersController(IUsersServices users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            var allUSers = this.users.GetAll();
            return View();
        }

        public ActionResult CompanyUsersViewModels_Read([DataSourceRequest]DataSourceRequest request)
        {
            var usersFromDb = this.users.GetAll();
            IQueryable<CompanyUsersViewModel> companyusersviewmodels = usersFromDb.To<CompanyUsersViewModel>();
            DataSourceResult result = companyusersviewmodels.ToDataSourceResult(request, companyUsersViewModel => new {
                Id = companyUsersViewModel.Id,
                Username = companyUsersViewModel.Username,
                Password = companyUsersViewModel.Password
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyUsersViewModels_Create([DataSourceRequest]DataSourceRequest request, CompanyUsersViewModel companyUsersViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CompanyUsersViewModel
                {
                    Username = companyUsersViewModel.Username,
                    Password = companyUsersViewModel.Password
                };

                this.users.Create(this.Mapper.Map<User>(entity));
                companyUsersViewModel.Id = entity.Id;
            }

            return Json(new[] { companyUsersViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyUsersViewModels_Update([DataSourceRequest]DataSourceRequest request, CompanyUsersViewModel companyUsersViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CompanyUsersViewModel
                {
                    Id = companyUsersViewModel.Id,
                    Username = companyUsersViewModel.Username,
                    Password = companyUsersViewModel.Password
                };

                this.users.Update(this.Mapper.Map<User>(entity));
            }

            return Json(new[] { companyUsersViewModel }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CompanyUsersViewModels_Destroy([DataSourceRequest]DataSourceRequest request, CompanyUsersViewModel companyUsersViewModel)
        {
            if (ModelState.IsValid)
            {
                var entity = new CompanyUsersViewModel
                {
                    Id = companyUsersViewModel.Id,
                    Username = companyUsersViewModel.Username,
                    Password = companyUsersViewModel.Password
                };

                this.users.DeleteById(entity.Id);
            }

            return Json(new[] { companyUsersViewModel }.ToDataSourceResult(request, ModelState));
        }
    }
}
