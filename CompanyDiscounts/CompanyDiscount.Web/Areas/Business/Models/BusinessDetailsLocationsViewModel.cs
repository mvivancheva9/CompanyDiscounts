using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyDiscount.Web.Infrastructure.Mapping;

namespace CompanyDiscount.Web.Areas.Business.Models
{
    public class BusinessDetailsLocationsViewModel : IMapFrom<CompanyDiscounts.Models.Business>
    {
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public int Discount { get; set; }

        public ICollection<BusinessLocationsViewModel> BusinessLocations { get; set; }
    }
}
