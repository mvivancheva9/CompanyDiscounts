﻿using CompanyDiscounts.Models;

namespace CompanyDiscounts.Services.Contracts
{
    using System.Linq;

    public interface ICompaniesServices
    {
        IQueryable<Company> GetAll();

        IQueryable<Company> GetDeleted();

        Company UpdateById(int id, string name, string description);

        Company UpdateDeletedById(int id, string name, string description, bool isDeleted);

        Company DeleteById(int id);

        Company Create(string name, string description);

        Company GetById(int id);
    }
}
