namespace OnlineCrystalStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class CrystalType : BaseModel<int>
    {
        private ICollection<Crystal> crystals;

        public CrystalType()
        {
            this.crystals = new HashSet<Crystal>();
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        // [MaxLength(1000)]
        // public string Description { get; set; }
        public virtual ICollection<Crystal> Crystals
        {
            get { return this.crystals; }
            set { this.crystals = value; }
        }
    }
}
