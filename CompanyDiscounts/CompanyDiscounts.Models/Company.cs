namespace CompanyDiscounts.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using CommonModels;

    public class Company : BaseModel<int>
    {
        private ICollection<CompanyBusiness> companyBusinesses;
        private ICollection<Logo> logos;
        private ICollection<EmployeeBusiness> employeeBusinesses; 

        public Company()
        {
            this.companyBusinesses = new HashSet<CompanyBusiness>();
            this.logos = new HashSet<Logo>();
            this.employeeBusinesses = new HashSet<EmployeeBusiness>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<CompanyBusiness> CompanyBusinesses { get; set; }

        public virtual ICollection<Logo> Logos { get; set; }
    }
}
