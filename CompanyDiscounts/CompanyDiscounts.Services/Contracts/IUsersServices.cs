using System.Linq;
using CompanyDiscounts.Models;

namespace CompanyDiscounts.Services.Contracts
{
    public interface IUsersServices
    {
        IQueryable<User> GetAll();

        User Update(User user);

        User DeleteById(string id);

        User Create(User user);

        User GetByName(string username);

        User GetById(string id);
    }
}
