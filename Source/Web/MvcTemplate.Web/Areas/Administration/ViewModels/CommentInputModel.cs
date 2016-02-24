namespace OnlineCrystalStore.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommentInputModel
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
    }
}
