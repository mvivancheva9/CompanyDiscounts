using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CompanyDiscount.Web.Infrastructure.Mapping;
using CompanyDiscounts.Models;

namespace CompanyDiscount.Web.Areas.Business.Models
{
    public class BusinessCompaniesViewModel : IMapFrom<CompanyBusiness>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int BusinessId { get; set; }

        [UIHint("CompanyEditor")]
        [HiddenInput(DisplayValue = false)]
        public CompanyViewModel Company { get; set; }

        [Required]
        public int Discount { get; set; }
    }
}
