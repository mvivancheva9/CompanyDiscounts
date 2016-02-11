using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
