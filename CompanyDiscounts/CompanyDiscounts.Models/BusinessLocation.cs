namespace CompanyDiscounts.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using CommonModels;

    public class BusinessLocation : BaseModel<int>
    {
        [Key]
        public int Id { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        [Required]
        public int BusinessId { get; set; }

        [ForeignKey("BusinessId")]
        public virtual Business Business { get; set; }
    }
}