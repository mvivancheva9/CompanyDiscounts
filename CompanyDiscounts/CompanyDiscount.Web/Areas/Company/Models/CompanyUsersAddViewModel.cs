using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CompanyDiscount.Web.Infrastructure.Mapping;
using CompanyDiscounts.Models;

namespace CompanyDiscount.Web.Areas.Company.Models
{
    public class CompanyUsersAddViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, CompanyUsersAddViewModel>()
                .ForMember(x => x.Password, opt => opt.MapFrom(x => x.PasswordHash));
        }
    }
}
