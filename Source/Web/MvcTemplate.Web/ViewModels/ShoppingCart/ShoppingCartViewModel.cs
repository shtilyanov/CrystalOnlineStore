namespace OnlineCrystalStore.Web.ViewModels.ShoppingCart
{
    using System.Collections.Generic;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ShoppingCartViewModel : IMapFrom<ShoppingCart>
    {
        public int Id { get; set; }

        public ICollection<Crystal> Crystals { get; set; }
    }
}
