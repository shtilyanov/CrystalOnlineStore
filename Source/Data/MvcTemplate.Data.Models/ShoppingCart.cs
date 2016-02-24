namespace OnlineCrystalStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Common.Models;

    public class ShoppingCart : BaseModel<int>
    {
        private ICollection<Crystal> crystals;

        public ShoppingCart()
        {
            this.crystals = new HashSet<Crystal>();
        }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Crystal> Crystals
        {
            get { return this.crystals; }
            set { this.crystals = value; }
        }
    }
}
