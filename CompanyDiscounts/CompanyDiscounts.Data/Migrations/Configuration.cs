// <copyright file="Configuration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using CompanyDiscounts.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CompanyDiscounts.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<CompanyDiscountsDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CompanyDiscountsDbContext context)
        {
            if (context.Company.Count() == 0)
            {
                context.Company.Add(new Company()
                {
                    Name = "Telerik",
                    Description = "Software Company"
                });
                context.SaveChanges();
            }

            context.Roles.AddOrUpdate(
              p => p.Name,
              new IdentityRole { Name = "Admin" },
              new IdentityRole { Name = "Company" },
              new IdentityRole { Name = "Business" },
              new IdentityRole { Name = "Employee" }
            );

            context.SaveChanges();
            if (!context.Users.Where(u => u.UserName == "admin@admin.com").Any())
            {
                var admin = new User
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    PasswordHash = "AJ6xY/N9kWRShbJYh8QE5fIt5Yg5IeyTFBnJ9RXAdIXUo9hiqxtVWRiYJ0XyUHVDbg==",
                    SecurityStamp = "59bcf0ca-0367-4397-b3c1-af413e479e0c",
                    LockoutEnabled = true,
                };

                context.Users.Add(admin);

                var role = context.Roles.Where(r => r.Name == "Admin").FirstOrDefault();
                var adminRole = new IdentityUserRole
                {
                    RoleId = role.Id
                };

                admin.Roles.Add(adminRole);
                context.SaveChanges();
            }
        }
    }
}
