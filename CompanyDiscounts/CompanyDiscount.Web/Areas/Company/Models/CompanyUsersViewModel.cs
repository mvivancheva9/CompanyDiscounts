using System.Web.Mvc;

namespace CompanyDiscount.Web.Areas.Company.Models
{
    using CompanyDiscounts.Models;
    using Infrastructure.Mapping;

    public class CompanyUsersViewModel : IMapFrom<User>
    {
        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        public string Username { get; set; }
    }
}
