using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyDiscounts.Models.CommonModels;

namespace CompanyDiscounts.Models
{
    public class Company : BaseModel<int>
    {
        private ICollection<CompanyBusiness> companyBusinesses;
        private ICollection<Logo> logos; 

        public Company()
        {
            this.companyBusinesses = new HashSet<CompanyBusiness>();
            this.logos = new HashSet<Logo>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<CompanyBusiness> CompanyBusinesses { get; set; } 

        public virtual ICollection<Logo> Logos { get; set; } 

        public virtual User User { get; set; }
    }
}
