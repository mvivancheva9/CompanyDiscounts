using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyDiscounts.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CommonModels;

    public class Company : BaseModel<int>
    {
        private ICollection<CompanyBusiness> companyBusinesses;
        private ICollection<EmployeeBusiness> employeeBusinesses;

        public Company()
        {
            this.companyBusinesses = new HashSet<CompanyBusiness>();
            this.employeeBusinesses = new HashSet<EmployeeBusiness>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<CompanyBusiness> CompanyBusinesses { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
