using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
