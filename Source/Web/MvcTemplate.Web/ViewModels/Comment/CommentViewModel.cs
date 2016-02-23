namespace OnlineCrystalStore.Web.ViewModels.Comment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Data.Models.Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [UIHint("SingleLineText")]
        public string Title { get; set; }

        [Required]
        [MaxLength(1500)]
        [UIHint("MultilineText")]
        public string Content { get; set; }

        [UIHint("String")]
        public string Author { get; set; }

        [UIHint("DateTime")]
        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Data.Models.Comment, CommentViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.Email));
        }
    }
}
