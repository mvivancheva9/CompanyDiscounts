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

        public Business()
        {
            this.businessLocations = new HashSet<BusinessLocation>();
            this.logos = new HashSet<Logo>();
            this.companyBusiness = new HashSet<CompanyBusiness>();
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
    }
}
