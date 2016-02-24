using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyDiscount.Web.Infrastructure.Mapping;

namespace CompanyDiscount.Web.Areas.Business.Models
{
    public class BusinessDetailsViewModel : IMapFrom<CompanyDiscounts.Models.Business>
    {
        public int Id { get; set; }

        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
