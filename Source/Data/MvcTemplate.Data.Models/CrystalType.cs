namespace OnlineCrystalStore.Data.Models
{
    using System.Collections.Generic;

    public class CrystalType
    {
        public CrystalType()
        {
            this.Crystals = new HashSet<Crystal>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Crystal> Crystals { get; set; }
    }
}
