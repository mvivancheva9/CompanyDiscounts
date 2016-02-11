// <copyright file="CompanyDiscountsDbContext.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyDiscounts.Models;
using System.Data.Entity;

namespace CompanyDiscounts.Data
{
    public class CompanyDiscountsDbContext : IdentityDbContext<User>, ICompanyDiscountsDbContext
    {
        public CompanyDiscountsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Business> Businesses { get; set; }

        public IDbSet<BusinessLocation> BusinessLocations { get; set; }

        public IDbSet<Logo> Logos { get; set; }

        public static CompanyDiscountsDbContext Create()
        {
            return new CompanyDiscountsDbContext();
        }
    }
}
