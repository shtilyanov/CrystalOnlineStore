namespace OnlineCrystalStore.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data.Models;
    using Infrastructure.Mapping;
    using AutoMapper;
    public class OrderViewModel : IMapFrom<OrderDetails>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Buyer { get; set; }

        public int ShoppingCartId { get; set; }

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

        public DateTime CreatedOn { get; set; }

        [UIHint("DateTime")]
        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [UIHint("DateTime")]
        public DateTime? DeletedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<OrderDetails, OrderViewModel>()
                .ForMember(x => x.Buyer, opt => opt.MapFrom(x => x.Buyer.Email));
        }
    }
}
