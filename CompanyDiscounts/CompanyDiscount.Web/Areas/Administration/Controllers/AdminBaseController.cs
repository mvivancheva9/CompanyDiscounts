using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyDiscount.Web.Controllers;

namespace CompanyDiscount.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBaseController : BaseController
    {  
    }
}