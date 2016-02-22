namespace OnlineCrystalStore.Web.ViewModels.Crystal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OnlineCrystalStore.Data.Models;
    using OnlineCrystalStore.Web.Infrastructure.Mapping;

    public class CrystalViewModel : IMapFrom<Crystal>
    {
        public int Id { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
