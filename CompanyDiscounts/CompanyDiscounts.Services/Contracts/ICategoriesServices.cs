using System.Linq;
using CompanyDiscounts.Models;

namespace CompanyDiscounts.Services.Contracts
{
    public interface ICategoriesServices
    {
        IQueryable<Category> GetAll();

        Category UpdateById(int id, string name, bool isDeleted);

        Category DeleteById(int id);

        Category Create(string name);

        Category GetById(int id);
    }
}
