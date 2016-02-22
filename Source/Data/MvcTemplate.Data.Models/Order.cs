namespace MvcTemplate.Data.Models
{
    using System.Collections.Generic;
    using OnlineCrystalStore.Data.Common.Models;
    using OnlineCrystalStore.Data.Models;

    public class Order : BaseModel<int>
    {
        private ICollection<Crystal> crystals;

        public Order()
        {
            this.crystals = new HashSet<Crystal>();
        }

        public string BuyerId { get; set; }

        public User Buyer { get; set; }

        public bool IsSent { get; set; }

        public bool IsDelivered { get; set; }

        public virtual ICollection<Crystal> Crystals
        {
            get { return this.crystals; }
            set { this.crystals = value; }
        }
    }
}
