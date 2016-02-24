namespace OnlineCrystalStore.Data.Models
{
    using System.Collections.Generic;
    using OnlineCrystalStore.Data.Common.Models;
    using OnlineCrystalStore.Data.Models;

    public class Order : BaseModel<int>
    {
        public string BuyerId { get; set; }

        public User Buyer { get; set; }

        public bool IsSent { get; set; }

        public bool IsDelivered { get; set; }
    }
}
