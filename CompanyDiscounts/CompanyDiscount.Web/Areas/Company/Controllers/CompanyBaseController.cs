using System.Web.Mvc;
using CompanyDiscount.Web.Controllers;

namespace CompanyDiscount.Web.Areas.Company.Controllers
{
    [Authorize(Roles = "Company")]
    public class CompanyBaseController : BaseController
    {
    }
}
