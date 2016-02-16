using AutoMapper;

namespace CompanyDiscount.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using CompanyDiscounts.Models;
    using Infrastructure.Mapping;

    public class CompanyUsersViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, CompanyUsersViewModel>()
                .ForMember(x => x.Password, opt => opt.MapFrom(x => x.PasswordHash));
        }
    }
}
