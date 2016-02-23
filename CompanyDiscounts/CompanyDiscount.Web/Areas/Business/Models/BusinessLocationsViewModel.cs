using System.ComponentModel.DataAnnotations;
using CompanyDiscount.Web.Infrastructure.Mapping;

namespace CompanyDiscount.Web.Areas.Business.Models
{
    public class BusinessLocationsViewModel : IMapFrom<CompanyDiscounts.Models.BusinessLocation>
    {
        public int Id { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        [Required]
        public int BusinessId { get; set; }
    }
}
