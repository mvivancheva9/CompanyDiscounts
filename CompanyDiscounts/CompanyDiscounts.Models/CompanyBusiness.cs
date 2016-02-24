using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CompanyDiscounts.Models.CommonModels;

namespace CompanyDiscounts.Models
{
    public class CompanyBusiness : BaseModel<int>
    {
        public int BusinessId { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("BusinessId")]
        public virtual Business Business { get; set; }

        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }

        [Required]
        public int Discount { get; set; }
    }
}
