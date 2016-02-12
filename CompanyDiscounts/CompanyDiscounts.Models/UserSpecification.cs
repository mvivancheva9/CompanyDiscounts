namespace CompanyDiscounts.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserSpecification
    {
        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public int? BusinessId { get; set; }

        [ForeignKey("BusinessId")]

        public Business Business { get; set; }

        public int? CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

    }
}
