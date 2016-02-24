using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyDiscount.Web.Areas.Business.Models;
using CompanyDiscounts.Models;

namespace CompanyDiscount.Web.Models
{
    public class CompaniesListViewModel
    {
        public IEnumerable<CompanyViewModel> Companies { get; set; }
    }
}
