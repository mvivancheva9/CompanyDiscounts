﻿namespace CompanyDiscounts.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Collections.Generic;


    public class User : IdentityUser
    {
        private ICollection<UserSpecification> userSpecifications;

        public User()
        {
            this.userSpecifications = new HashSet<UserSpecification>();
        }

        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Add custom user claims here
            return userIdentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(this.GenerateUserIdentity(manager));
        }

        public virtual ICollection<UserSpecification> UserSpecification { get; set; }
    }
}
