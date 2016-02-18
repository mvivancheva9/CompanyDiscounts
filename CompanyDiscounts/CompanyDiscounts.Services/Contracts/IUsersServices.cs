using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
