namespace CompanyDiscount.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Infrastructure.Mapping;

    public class CompaniesViewModel : IMapFrom<CompanyDiscounts.Models.Company>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
