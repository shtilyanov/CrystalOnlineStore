namespace OnlineCrystalStore.Web.ViewModels.OrderDetails
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using OnlineCrystalStore.Data.Models;
    using OnlineCrystalStore.Web.Infrastructure.Mapping;

    public class OrderDetailsViewModel : IMapFrom<OrderDetails>/*, IHaveCustomMappings*/
    {
        public int Id { get; set; }

        public string BuyerId { get; set; }

        public int ShoppingCartId { get; set; }

        public decimal TotalPrice { get; set; }

        [Required]
        [MaxLength(50)]
        [UIHint("SingleLineText")]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        [UIHint("SingleLineText")]
        public string City { get; set; }

        [Required]
        [MaxLength(550)]
        [UIHint("MultilineText")]
        public string Address { get; set; }

        [Required]
        [UIHint("SingleLineText")]
        [Display(Name = "Payment Method")]
        public PaymentMethodType PaymentMethod { get; set; }

        // public void CreateMappings(IMapperConfiguration configuration)
        // {
        //     configuration.CreateMap<ShoppingCart, OrderDetailsViewModel>()
        //         .ForMember(x => x.TotalPrice, opt => opt.MapFrom(x => x.Crystals.Sum(c => c.Price)));
        // }
    }
}
