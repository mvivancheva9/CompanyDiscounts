using System;
using System.Linq;
using CompanyDiscounts.Data.Repositories;
using CompanyDiscounts.Models;
using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscounts.Services
{
    public class CompanyBusinessesServices : ICompanyBusinessesServices
    {
        private IRepository<CompanyBusiness> companyBusinesses;

        public CompanyBusinessesServices(IRepository<CompanyBusiness> companyBusinesses)
        {
            this.companyBusinesses = companyBusinesses;
        }

        public IQueryable<CompanyBusiness> GetAll(int id)
        {
            return this.companyBusinesses.All().Where(cb => cb.BusinessId == id);
        }

        public IQueryable<CompanyBusiness> GetDeleted(int id)
        {
            var allbusinessCompanies = this.companyBusinesses.All().Where(cb => cb.BusinessId == id);

            return allbusinessCompanies.Where(cb => cb.IsDeleted);
        }

        public CompanyBusiness DeleteById(int id)
        {
            var businessCompanyToDelete = this.companyBusinesses.GetById(id);

            businessCompanyToDelete.IsDeleted = true;

            businessCompanyToDelete.DeletedOn = DateTime.Now;

            this.companyBusinesses.SaveChanges();

            return businessCompanyToDelete;
        }

        public CompanyBusiness Create(CompanyBusiness companyBusiness)
        {
            this.companyBusinesses.Add(companyBusiness);

            this.companyBusinesses.SaveChanges();

            return companyBusiness;
        }

        public CompanyBusiness Update(CompanyBusiness companyBusiness)
        {
            var businessCompanyToUpdate = this.companyBusinesses.GetById(companyBusiness.Id);

            businessCompanyToUpdate.CompanyId = companyBusiness.CompanyId;
            businessCompanyToUpdate.Discount = companyBusiness.Discount;

            this.companyBusinesses.SaveChanges();

            return businessCompanyToUpdate;
        }

        public CompanyBusiness GetById(int id)
        {
            return this.companyBusinesses.GetById(id);
        }

        public IQueryable<Business> GetByCompanyId(int id)
        {
            return this.companyBusinesses.All().Where(cb => cb.CompanyId == id).Select(cb => cb.Business);
        }

        public CompanyBusiness GetByCompanyIdBusinessId(int companyId, int businessId)
        {
            return
                this.companyBusinesses
                    .All()
                    .FirstOrDefault(cb => (cb.BusinessId == businessId) && (cb.CompanyId == companyId));
        }
    }
}
