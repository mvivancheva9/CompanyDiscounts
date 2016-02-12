namespace CompanyDiscount.Web.ViewModels.Companies
{
    using CompanyDiscounts.Models;
    using Infrastructure.Mapping;

    public class CompanyDetailsViewModel : IMapFrom<Company>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
