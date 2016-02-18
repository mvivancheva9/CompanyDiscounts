namespace CompanyDiscounts.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface IBusinessesServices
    {
        IQueryable<Business> GetAll();

        IQueryable<Business> GetDeleted();

        Business UpdateById(int id, string name, string description);

        Business UpdateDeletedById(int id, string name, string description, bool isDeleted);

        Business DeleteById(int id);

        Business Create(string name, string description);

        Business GetById(int id);

        Business GetByUserId(string userId);

        Business UpdateById(int id, string userId);
    }
}
