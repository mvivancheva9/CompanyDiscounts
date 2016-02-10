using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyDiscounts.Models;

namespace CompanyDiscounts.Data
{
    public class CompanyDiscountsDbContext : IdentityDbContext<User>, ICompanyDiscountsDbContext
    {
        public CompanyDiscountsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CompanyDiscountsDbContext Create()
        {
            return new CompanyDiscountsDbContext();
        }
    }
}
