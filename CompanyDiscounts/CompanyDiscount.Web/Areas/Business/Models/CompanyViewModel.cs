using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyDiscount.Web.Infrastructure.Mapping;

namespace CompanyDiscount.Web.Areas.Business.Models
{
    public class CompanyViewModel : IMapFrom<CompanyDiscounts.Models.Company>
    {
        [DisplayName("Company")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
