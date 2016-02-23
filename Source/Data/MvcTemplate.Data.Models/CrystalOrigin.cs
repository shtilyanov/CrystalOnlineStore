namespace OnlineCrystalStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class CrystalOrigin : BaseModel<int>
    {
        private ICollection<Crystal> crystals;

        public CrystalOrigin()
        {
            this.crystals = new HashSet<Crystal>();
        }

        // [Required]
        // [MaxLength(50)]
        // public string Region { get; set; }
        [MaxLength(100)]
        public string Mine { get; set; }

        public virtual ICollection<Crystal> Crystals
        {
            get { return this.crystals; }
            set { this.crystals = value; }
        }
    }
}
