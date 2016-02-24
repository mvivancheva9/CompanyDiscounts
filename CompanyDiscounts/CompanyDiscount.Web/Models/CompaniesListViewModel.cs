using System.Collections.Generic;
using CompanyDiscount.Web.Areas.Business.Models;

namespace CompanyDiscount.Web.Models
{
    public class CompaniesListViewModel
    {
        public IEnumerable<CompanyViewModel> Companies { get; set; }
    }
}
