namespace CompanyDiscounts.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CommonModels;

    public class Business : BaseModel<int>
    {
        private ICollection<BusinessLocation> businessLocations;
        private ICollection<Logo> logos;
        private ICollection<CompanyBusiness> companyBusiness;
        private ICollection<EmployeeBusiness> employeeBusinesses; 

        public Business()
        {
            this.businessLocations = new HashSet<BusinessLocation>();
            this.logos = new HashSet<Logo>();
            this.companyBusiness = new HashSet<CompanyBusiness>();
            this.employeeBusinesses = new HashSet<EmployeeBusiness>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<BusinessLocation> BusinessLocations { get; set; }

        public virtual ICollection<Logo> Logos { get; set; }

        public virtual ICollection<CompanyBusiness> CompanyBusinesses { get; set; }

        public virtual ICollection<EmployeeBusiness> EmployeeBusinesses { get; set; }

        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
