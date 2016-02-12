namespace CompanyDiscounts.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
