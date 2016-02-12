using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDiscounts.Models
{
    public class Employee
    {
        private ICollection<EmployeeBusiness> employeeBusinesses;

        public Employee()
        {
            this.employeeBusinesses = new HashSet<EmployeeBusiness>();
        }

        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public UserSpecification UserSpecification { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public virtual ICollection<EmployeeBusiness> EmployeeBusinesses { get; set; } 

    }
}
