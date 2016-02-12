namespace CompanyDiscounts.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Models.CommonModels;

    public class CompanyDiscountsDbContext : IdentityDbContext<User>, ICompanyDiscountsDbContext
    {
        public CompanyDiscountsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Business> Business { get; set; }

        public IDbSet<BusinessLocation> BusinessLocation { get; set; }

        public IDbSet<Logo> Logo { get; set; }

        public IDbSet<Company> Company { get; set; } 

        public IDbSet<CompanyBusiness> CompanyBusiness { get; set; } 

        public IDbSet<Employee> Employee { get; set; }
        
        public IDbSet<EmployeeBusiness> EmployeeBusiness { get; set; }
        
        public IDbSet<UserSpecification> UserSpecification { get; set; } 

        public static CompanyDiscountsDbContext Create()
        {
            return new CompanyDiscountsDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }


        public void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
