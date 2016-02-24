﻿namespace CompanyDiscounts.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Employee
    {
        private ICollection<EmployeeBusiness> employeeBusinesses;

        public Employee()
        {
            this.employeeBusinesses = new HashSet<EmployeeBusiness>();
        }

        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        public virtual ICollection<EmployeeBusiness> EmployeeBusinesses { get; set; } 

    }
}
