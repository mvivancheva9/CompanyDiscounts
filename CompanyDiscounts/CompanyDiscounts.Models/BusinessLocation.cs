using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyDiscounts.Models
{
    public class BusinessLocation
    {
        public int ID { get; set; }

        public double longitude { get; set; }

        public double latitude { get; set; }

        [Required]
        public int BusinessId { get; set; }

        [ForeignKey("BusinessId")]
        public virtual Business Business { get; set; }
    }
}