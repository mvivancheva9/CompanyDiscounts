using System.Web.Mvc;
using CompanyDiscount.Web.Controllers;

namespace CompanyDiscount.Web.Areas.Business.Controllers
{
    [Authorize(Roles = "Business")]
    public class BusinessBaseController : BaseController
    {
    }
}