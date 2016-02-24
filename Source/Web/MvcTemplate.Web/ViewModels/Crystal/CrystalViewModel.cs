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
        [UIHint("Currency")]
        public decimal Price { get; set; }

        [MaxLength(100)]
        [UIHint("SingleLineText")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Size of crystal")]
        [UIHint("SingleLineText")]
        public string Size { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Weight of crystal")]
        [UIHint("SingleLineText")]
        public string Weight { get; set; }

        [MaxLength(1000)]
        [UIHint("MultilineText")]
        public string Description { get; set; }

        [MaxLength(100)]
        [UIHint("SingleLineText")]
        public string Mine { get; set; }

        [Display(Name = "Image")]
        public HttpPostedFileBase UploadedCrystalImage { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<CrystalOrigin, CrystalViewModel>()
                .ForMember(x => x.Mine, opt => opt.MapFrom(x => x.Mine));
        }
    }
}
