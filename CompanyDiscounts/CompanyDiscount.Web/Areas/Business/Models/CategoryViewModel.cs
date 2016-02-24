using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyDiscount.Web.Infrastructure.Mapping;
using CompanyDiscounts.Models;

namespace CompanyDiscount.Web.Areas.Business.Models
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
