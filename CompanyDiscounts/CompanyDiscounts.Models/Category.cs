using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyDiscounts.Models.CommonModels;

namespace CompanyDiscounts.Models
{
    public class Category : BaseModel<int>
    {
        private ICollection<Business> businesses;

        public Category()
        {
            this.businesses = new HashSet<Business>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Business> Businesses { get; set; }
    }
}
