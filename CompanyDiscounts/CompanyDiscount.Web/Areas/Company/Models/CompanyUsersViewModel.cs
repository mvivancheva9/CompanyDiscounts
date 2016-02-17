using AutoMapper;

namespace CompanyDiscount.Web.Areas.Company.Models
{
    using System.ComponentModel.DataAnnotations;
    using CompanyDiscounts.Models;
    using Infrastructure.Mapping;

    public class CompanyUsersViewModel : IMapFrom<User>
    { 
        public string Id { get; set; }

        public string Username { get; set; }
    }
}
