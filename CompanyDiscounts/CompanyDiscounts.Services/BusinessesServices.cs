using System;
using System.Linq;
using CompanyDiscounts.Data.Repositories;
using CompanyDiscounts.Models;
using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscounts.Services
{
    public class BusinessesServices : IBusinessesServices
    {
        private IRepository<Business> businesses;

        public BusinessesServices(IRepository<Business> businesses)
        {
            this.businesses = businesses;
        }

        public IQueryable<Business> GetAll()
        {
            return this.businesses.All().Where(c => c.IsDeleted == false);
        }

        public IQueryable<Business> GetDeleted()
        {
            return this.businesses.All().Where(c => c.IsDeleted);
        }

        public Business UpdateById(int id, string name, string description)
        {
            var businessToUpdate = this.businesses.GetById(id);

            businessToUpdate.Name = name;

            businessToUpdate.Description = description;

            this.businesses.SaveChanges();

            return businessToUpdate;
        }

        public Business Update(Business business)
        {
            var businessToUpdate = this.businesses.GetById(business.Id);

            businessToUpdate.Description = business.Description;

            businessToUpdate.CategoryId = business.CategoryId;

            this.businesses.SaveChanges();

            return businessToUpdate;
        }

        public Business UpdateDeletedById(int id, string name, string description, bool isDeleted)
        {
            var businessyToUpdate = this.businesses.GetById(id);

            businessyToUpdate.Name = name;

            businessyToUpdate.Description = description;

            businessyToUpdate.IsDeleted = isDeleted;

            this.businesses.SaveChanges();

            return businessyToUpdate;
        }

        public Business DeleteById(int id)
        {
            var businessToDelete = this.businesses.GetById(id);

            businessToDelete.DeletedOn = DateTime.Now;

            businessToDelete.IsDeleted = true;

            this.businesses.SaveChanges();

            return businessToDelete;
        }

        public Business Create(string name, string description)
        {
            var newBusiness = new Business()
            {
                Name = name,
                Description = description
            };
            this.businesses.Add(newBusiness);

            this.businesses.SaveChanges();

            return newBusiness;
        }

        public Business GetById(int id)
        {
            return this.businesses.GetById(id);
        }

        public Business GetByUserId(string userId)
        {
            var currentBusiness = this.businesses.All().Where(b => b.UserId == userId).FirstOrDefault();

            return currentBusiness;
        }

        public Business UpdateById(int id, string userId)
        {
            var businessToUpdate = this.businesses.GetById(id);

            businessToUpdate.UserId = userId;

            this.businesses.SaveChanges();

            return businessToUpdate;
        }
    }
}