// <copyright file="DbConfig.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using CompanyDiscounts.Data;
using CompanyDiscounts.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDiscount.Web
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDiscountsDbContext, Configuration>());

            CompanyDiscountsDbContext.Create().Database.Initialize(true);
        }
    }
}
