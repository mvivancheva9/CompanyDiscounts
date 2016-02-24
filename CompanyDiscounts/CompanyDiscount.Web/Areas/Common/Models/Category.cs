using CompanyDiscount.Web.Infrastructure.Mapping;

namespace CompanyDiscount.Web.Areas.Common.Models
{
    public class Category : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
