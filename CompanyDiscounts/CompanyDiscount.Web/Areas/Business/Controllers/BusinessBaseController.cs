﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyDiscount.Web.Areas.Administration.Models;
using CompanyDiscount.Web.Controllers;
using CompanyDiscounts.Services.Contracts;
using Microsoft.AspNet.Identity;

namespace CompanyDiscount.Web.Areas.Business.Controllers
{
    [Authorize(Roles = "Business")]
    public class BusinessBaseController : BaseController
    {
        private IBusinessesServices businesses;

        public BusinessBaseController(IBusinessesServices businesses)
        {
            this.businesses = businesses;
        }

        protected BusinessesViewModel CurrentBusiness()
        {
            return this.Mapper.Map<BusinessesViewModel>(this.businesses.GetByUserId(this.User.Identity.GetUserId()));
        }
    }
}