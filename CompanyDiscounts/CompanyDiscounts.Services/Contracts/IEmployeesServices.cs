using System.Linq;
using CompanyDiscounts.Models;

namespace CompanyDiscounts.Services.Contracts
{
    public interface IEmployeesServices
    {
        IQueryable<Employee> GetAll(int id);

        void Delete(Employee employee);

        Employee Create(Employee employee);

        Employee GetById(int id);

        Employee GetByUserId(string id);
    }
}
