// <copyright file="Configuration.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using CompanyDiscounts.Models;

namespace CompanyDiscounts.Data.Migrations
{
    using System;
    using System.Data.Entity;
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
            
        }
    }
}
