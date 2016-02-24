namespace OnlineCrystalStore.Web.ViewModels.PagebleCommentList
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Infrastructure.Mapping;

    public class PagebleCommentViewModel : IMapFrom<Data.Models.Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        [UIHint("String")]
        public string Author { get; set; }

        [UIHint("DateTime")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.Comment, PagebleCommentViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.Email));
        }
    }
}
