// <copyright file="BusinessLocation.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyDiscounts.Models
{
    public class BusinessLocation
    {
        public int ID { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        [Required]
        public int BusinessId { get; set; }

        [ForeignKey("BusinessId")]
        public virtual Business Business { get; set; }
    }
}