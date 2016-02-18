// <copyright file="DbConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CompanyDiscount.Web
{
    using System.Data.Entity;
    using CompanyDiscounts.Data;
    using CompanyDiscounts.Data.Migrations;

    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDiscountsDbContext, Configuration>());

            CompanyDiscountsDbContext.Create().Database.Initialize(true);
        }
    }
}
