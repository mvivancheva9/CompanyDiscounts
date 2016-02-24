using System.Collections.Generic;
using CompanyDiscount.Web.Areas.Business.Models;

namespace CompanyDiscount.Web.Models
{
    public class BusinessListViewModel
    {
        public IEnumerable<BusinessDetailsLocationsViewModel> Businesses { get; set; }
    }
}
