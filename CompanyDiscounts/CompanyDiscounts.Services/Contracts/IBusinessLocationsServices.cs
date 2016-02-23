using System.Linq;
using CompanyDiscounts.Models;

namespace CompanyDiscounts.Services.Contracts
{
    public interface IBusinessLocationsServices
    {
        IQueryable<BusinessLocation> GetAll(int id);

        IQueryable<BusinessLocation> GetDeleted(int id);

        BusinessLocation DeleteById(int id);

        BusinessLocation Create(BusinessLocation businessLocation);

        BusinessLocation GetById(int id);
    }
}
