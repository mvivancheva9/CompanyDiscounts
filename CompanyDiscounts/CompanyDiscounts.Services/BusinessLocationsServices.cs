using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyDiscounts.Data.Repositories;
using CompanyDiscounts.Models;
using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscounts.Services
{
    public class BusinessLocationsServices : IBusinessLocationsServices
    {
        private IRepository<BusinessLocation> businessLocations;

        public BusinessLocationsServices(IRepository<BusinessLocation> businessLocations)
        {
            this.businessLocations = businessLocations;
        }

        public IQueryable<BusinessLocation> GetAll(int id)
        {
            return this.businessLocations.All().Where(l => l.BusinessId == id);
        }

        public IQueryable<BusinessLocation> GetDeleted(int id)
        {
            var currentBusinessLocations = this.businessLocations.All().Where(l => l.BusinessId == id);

            return currentBusinessLocations.Where(l => l.IsDeleted);
        }

        public BusinessLocation DeleteById(int id)
        {
            var currentBusinessLocation = this.businessLocations.GetById(id);

            currentBusinessLocation.IsDeleted = true;

            currentBusinessLocation.DeletedOn = DateTime.Now;

            this.businessLocations.SaveChanges();

            return currentBusinessLocation;
        }

        public BusinessLocation Create(BusinessLocation businessLocation)
        {
            var newBusinessLocation = new BusinessLocation()
            {
                BusinessId = businessLocation.BusinessId,
                Latitude = businessLocation.Latitude,
                Longitude = businessLocation.Longitude
            };
            this.businessLocations.Add(newBusinessLocation);

            this.businessLocations.SaveChanges();

            return newBusinessLocation;
        }

        public BusinessLocation GetById(int id)
        {
            return this.businessLocations.GetById(id);
        }
    }
}
