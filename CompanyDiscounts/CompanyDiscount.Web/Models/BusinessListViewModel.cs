using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyDiscount.Web.Areas.Business.Models;

namespace CompanyDiscount.Web.Models
{
    public class BusinessListViewModel
    {
        public IEnumerable<BusinessDetailsViewModel> Businesses { get; set; }
    }
}
