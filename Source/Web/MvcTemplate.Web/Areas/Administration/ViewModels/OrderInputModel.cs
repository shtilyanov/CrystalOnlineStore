namespace OnlineCrystalStore.Web.Areas.Administration.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data.Models;

    public class OrderInputModel
    {
        public int Id { get; set; }

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
    }
}
