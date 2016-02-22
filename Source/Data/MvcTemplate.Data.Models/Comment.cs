namespace OnlineCrystalStore.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using OnlineCrystalStore.Data.Common.Models;
    using OnlineCrystalStore.Data.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1500)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
