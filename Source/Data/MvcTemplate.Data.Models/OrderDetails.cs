namespace OnlineCrystalStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using OnlineCrystalStore.Data.Common.Models;

    public class OrderDetails : BaseModel<int>
    {
        public string BuyerId { get; set; }

        public User Buyer { get; set; }

        public int ShoppingCartId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(550)]
        public string Address { get; set; }

        public PaymentMethodType PaymentMethod { get; set; }
    }
}
