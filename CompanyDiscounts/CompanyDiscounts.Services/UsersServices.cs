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
    public class UsersServices : IUsersServices
    {
        private IRepository<User> users;

        public UsersServices(IRepository<User> users)
        {
            this.users = users;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public User Update(User user)
        {
            var userToUpdate = this.users.GetByName(user.UserName);

            userToUpdate.UserName = user.UserName;

            this.users.SaveChanges();

            return userToUpdate;
        }

        public User DeleteById(string id)
        {
            var userToDelete = this.users.GetByName(id);

            this.users.Delete(userToDelete);

            this.users.SaveChanges();

            return userToDelete;
        }

        public User Create(User user)
        {
            var newUser = new User()
            {
                UserName = user.UserName,
                PasswordHash = user.PasswordHash
            };

            this.users.Add(newUser);
            this.users.SaveChanges();

            return newUser;
        }

        public User GetByName(string id)
        {
            var user = this.users.GetByName(id);

            return user;
        }

        public User GetById(string id)
        {
            var user = this.users.GetById(id);

            return user;
        }
    }
}
