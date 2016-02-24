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
    public class EmployeesServices : IEmployeesServices
    {
        private IRepository<Employee> employees;

        public EmployeesServices(IRepository<Employee> employees)
        {
            this.employees = employees;
        }

        public IQueryable<Employee> GetAll(int id)
        {
            return this.employees.All().Where(e => e.CompanyId == id);
        }

        public void Delete(Employee employee)
        {
           this.employees.Delete(employee);

            this.employees.SaveChanges();
        }

        public Employee Create(Employee employee)
        {
            this.employees.Add(employee);

            this.employees.SaveChanges();

            return employee;
        }

        public Employee GetById(int id)
        {
            return this.employees.GetById(id);
        }

        public Employee GetByUserId(string id)
        {
            return this.employees.All().FirstOrDefault(e => e.UserId == id);
        }
    }
}
