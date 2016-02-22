namespace OnlineCrystalStore.Web.ViewModels.Crystal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web;
    using AutoMapper;
    using OnlineCrystalStore.Data.Models;
    using OnlineCrystalStore.Web.Infrastructure.Mapping;

    public class CrystalViewModel : IMapFrom<Crystal>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Size of crystal")]
        public string Size { get; set; }

        [Required]
        [Display(Name = "Weight of crystal")]
        public int Weight { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Region { get; set; }

        [MaxLength(100)]
        public string Mine { get; set; }

        [MaxLength(100)]
        public string Type { get; set; }

        [Display(Name = "Image")]
        public HttpPostedFileBase UploadedCrystalImage { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<CrystalOrigin, CrystalViewModel>()
                .ForMember(x => x.Region, opt => opt.MapFrom(x => x.Region))
                .ForMember(x => x.Mine, opt => opt.MapFrom(x => x.Mine));

            configuration.CreateMap<CrystalType, CrystalViewModel>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.Name));
        }
    }
}
