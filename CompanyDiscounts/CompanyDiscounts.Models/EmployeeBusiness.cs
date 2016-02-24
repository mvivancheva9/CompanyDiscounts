namespace CompanyDiscounts.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class EmployeeBusiness
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id")]
        public Employee Employee { get; set; }

        public int BusinessId { get; set; }

        [ForeignKey("BusinessId")]
        public Business Business { get; set; }
    }
}
