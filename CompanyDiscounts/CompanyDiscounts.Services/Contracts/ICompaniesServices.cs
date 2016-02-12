using CompanyDiscounts.Models;

namespace CompanyDiscounts.Services.Contracts
{
    using System.Linq;

    public interface ICompaniesServices
    {
        IQueryable<Company> GetAll();

        Company UpdateById(int id, string name, string description);

        Company DeleteById(int id);

        Company Create(string name, string description);

        Company GetById(int id);
    }
}
