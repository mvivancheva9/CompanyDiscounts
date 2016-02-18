using AutoMapper;

namespace CompanyDiscount.Web.Areas.Administration.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Infrastructure.Mapping;

    public class BusinessesViewModel : IMapFrom<CompanyDiscounts.Models.Business>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        //[UIHint("BusinessCategoriesEditor")]
        public string Category { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<CompanyDiscounts.Models.Business, BusinessesViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
