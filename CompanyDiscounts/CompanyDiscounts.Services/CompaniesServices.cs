namespace CompanyDiscounts.Services
{
    using System;
    using System.Linq;
    using Data.Repositories;
    using Models;
    using Contracts;

    public class CompaniesServices : ICompaniesServices
    {
        private IRepository<Company> companies;

        public CompaniesServices(IRepository<Company> companies)
        {
            this.companies = companies;
        }

        public IQueryable<Company> GetAll()
        {
           return this.companies.All().Where(c => c.IsDeleted == false);
        }

        public IQueryable<Company> GetDeleted()
        {
            return this.companies.All().Where(c => c.IsDeleted);
        }

        public Company UpdateById(int id, string name, string description)
        {
            var companyToUpdate = this.companies.GetById(id);

            companyToUpdate.Name = name;

            companyToUpdate.Description = description;

            this.companies.SaveChanges();

            return companyToUpdate;
        }

        public Company UpdateDeletedById(int id, string name, string description, bool isDeleted)
        {
            var companyToUpdate = this.companies.GetById(id);

            companyToUpdate.Name = name;

            companyToUpdate.Description = description;

            companyToUpdate.IsDeleted = isDeleted;

            this.companies.SaveChanges();

            return companyToUpdate;
        }

        public Company DeleteById(int id)
        {
            var companyToDelete = this.companies.GetById(id);

            companyToDelete.DeletedOn = DateTime.Now;

            companyToDelete.IsDeleted = true;

            this.companies.SaveChanges();

            return companyToDelete;
        }

        public Company Create(string name, string description)
        {
            var newCompany = new Company()
            {
                Name = name,
                Description = description
            };
            this.companies.Add(newCompany);

            this.companies.SaveChanges();

            return newCompany;
        }

        public Company GetById(int id)
        {
            return this.companies.GetById(id);
        }
    }
}
