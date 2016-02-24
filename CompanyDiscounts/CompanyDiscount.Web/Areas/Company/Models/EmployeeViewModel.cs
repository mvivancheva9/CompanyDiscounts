using AutoMapper;
using CompanyDiscount.Web.Infrastructure.Mapping;

namespace CompanyDiscount.Web.Areas.Company.Models
{
    public class EmployeeViewModel : IMapFrom<CompanyDiscounts.Models.Employee>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public int CompanyId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<CompanyDiscounts.Models.Employee, EmployeeViewModel>()
                .ForMember(x => x.Username, opt => opt.MapFrom(x => x.User.UserName));
        }
    }
}
