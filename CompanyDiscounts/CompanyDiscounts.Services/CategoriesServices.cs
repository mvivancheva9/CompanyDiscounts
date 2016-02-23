using System;
using System.Linq;
using CompanyDiscounts.Data.Repositories;
using CompanyDiscounts.Models;
using CompanyDiscounts.Services.Contracts;

namespace CompanyDiscounts.Services
{
    public class CategoriesServices :ICategoriesServices
    {
        private IRepository<Category> categories;

        public CategoriesServices(IRepository<Category> categories)
        {
            this.categories = categories;
        }

        public IQueryable<Category> GetAll()
        {
           return this.categories.All();
        }

        public Category UpdateById(int id, string name, bool isDeleted)
        {
            var categoryToUpdate = this.categories.GetById(id);

            categoryToUpdate.Name = name;

            categoryToUpdate.IsDeleted = isDeleted;

            this.categories.SaveChanges();

            return categoryToUpdate;
        }

        public Category DeleteById(int id)
        {
            var categoryToDelete = this.categories.GetById(id);

            categoryToDelete.DeletedOn = DateTime.Now;

            categoryToDelete.IsDeleted = true;

            this.categories.SaveChanges();

            return categoryToDelete;
        }

        public Category Create(string name)
        {
            var newCategory = new Category()
            {
                Name = name
            };
            this.categories.Add(newCategory);

            this.categories.SaveChanges();

            return newCategory;
        }

        public Category GetById(int id)
        {
            return this.categories.GetById(id);
        }
    }
}
