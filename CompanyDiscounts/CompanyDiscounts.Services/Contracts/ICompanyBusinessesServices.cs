namespace CompanyDiscounts.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface ICompanyBusinessesServices
    {
        IQueryable<CompanyBusiness> GetAll(int id);

        IQueryable<CompanyBusiness> GetDeleted(int id);

        CompanyBusiness DeleteById(int id);

        CompanyBusiness Create(CompanyBusiness companyBusiness);

        CompanyBusiness Update(CompanyBusiness companyBusiness);

        CompanyBusiness GetById(int id);

        IQueryable<Business> GetByCompanyId(int id);
    }
}
