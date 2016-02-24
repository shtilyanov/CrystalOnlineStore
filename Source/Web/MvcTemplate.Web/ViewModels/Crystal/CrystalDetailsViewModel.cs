namespace OnlineCrystalStore.Web.ViewModels.Crystal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using OnlineCrystalStore.Data.Models;
    using OnlineCrystalStore.Web.Infrastructure.Mapping;

    public class CrystalDetailsViewModel : IMapFrom<Crystal>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string Mine { get; set; }

        public string Size { get; set; }

        public string Weight { get; set; }

        public int? CrystalPictureId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Crystal, CrystalDetailsViewModel>()
        .ForMember(x => x.Mine, opt => opt.MapFrom(x => x.CristalOrigin.Mine));
        }
    }
}
