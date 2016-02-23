// <copyright file="Logo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CompanyDiscounts.Models
{
    public class Logo
    {
        public int Id { get; set; }

        public string OriginalName { get; set; }

        public string FileExtension { get; set; }

        public byte[] FileContent { get; set; }

        public string Url { get; set; }

        public int? BusinessId { get; set; }

        public virtual Business Business { get; set; }

        public int? CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
