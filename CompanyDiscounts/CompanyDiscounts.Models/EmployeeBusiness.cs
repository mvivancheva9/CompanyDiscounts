using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDiscounts.Models
{
    public class EmployeeBusiness
    {
        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public Employee Employee { get; set; }

        public int BusinessId { get; set; }

        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
    }
}
