using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using CompanyDiscount.Web.Infrastructure.Mapping;
using CompanyDiscounts.Models;

namespace CompanyDiscount.Web.Areas.Business.Models
{
    public class BusinessCompaniesViewModel : IMapFrom<CompanyBusiness>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int BusinessId { get; set; }

        [UIHint("CompanyEditor")]
        public CompanyViewModel Company { get; set; }

        [Required]
        public int Discount { get; set; }
    }
}
