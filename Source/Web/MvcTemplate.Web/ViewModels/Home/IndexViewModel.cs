namespace OnlineCrystalStore.Web.ViewModels.Home
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

    public class IndexViewModel : IMapFrom<Crystal>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int? CrystalPictureId { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<CrystalType, IndexViewModel>()
        .ForMember(x => x.Type, opt => opt.MapFrom(x => x.Name));
        }
    }
}
