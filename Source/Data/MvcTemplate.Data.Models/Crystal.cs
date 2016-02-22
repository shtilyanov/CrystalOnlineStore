﻿namespace OnlineCrystalStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using OnlineCrystalStore.Data.Models;

    public class Crystal : BaseModel<int>
    {
        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        public string Size { get; set; }

        [Required]
        public int Weight { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public bool IsSold { get; set; }

        public int CrysalTypeId { get; set; }

        public virtual CrystalType CrystalType { get; set; }

        public int CrystalOriginId { get; set; }

        public virtual CrystalOrigin CristalOrigin { get; set; }

        public int CrystalPictureId { get; set; }

        public virtual CrystalPicture CrystalPicture { get; set; }
    }
}
