using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDiscounts.Models
{
    public class Logo
    {
        public int Id { get; set; }

        public string OriginalName { get; set; }

        public string FileExtension { get; set; }

        public byte[] FileContent { get; set; }

        public string Url { get; set; }

        [Required]
        public int BusinessId { get; set; }

        public virtual Business Business { get; set; }
    }
}
