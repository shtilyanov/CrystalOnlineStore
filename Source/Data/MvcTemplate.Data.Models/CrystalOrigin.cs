namespace OnlineCrystalStore.Data.Models
{
    using System.Collections.Generic;

    public class CrystalOrigin
    {
        public CrystalOrigin()
        {
            this.Crystals = new HashSet<Crystal>();
        }

        public int Id { get; set; }

        public string Region { get; set; }

        public string Mine { get; set; }

        public virtual ICollection<Crystal> Crystals { get; set; }
    }
}
