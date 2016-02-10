namespace CompanyDiscounts.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Business
    {
        private ICollection<BusinessLocation> businessLocations;
        private ICollection<Logo> logos;
        public Business()
        {
            this.businessLocations = new HashSet<BusinessLocation>();
            this.logos = new HashSet<Logo>();
        }

        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<BusinessLocation> BusinessLocation { get; set; }

        public virtual ICollection<Logo> Logo { get; set; }
    }
}
