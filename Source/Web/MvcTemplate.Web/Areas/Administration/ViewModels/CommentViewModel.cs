namespace OnlineCrystalStore.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using OnlineCrystalStore.Data.Models;
    using OnlineCrystalStore.Web.Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
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

        [UIHint("DateTime")]
        public DateTime? ModifiedOn { get; set; }

        [Index]
        public bool IsDeleted { get; set; }

        [UIHint("DateTime")]
        public DateTime? DeletedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.Email));
        }
    }
}
