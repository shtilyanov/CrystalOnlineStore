namespace OnlineCrystalStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Data.Common;
    using Data.Models;
    using Microsoft.AspNet.Identity;
    using ViewModels.ShoppingCart;

    [Authorize]
    public class ShoppingCartController : BaseController
    {
        private IDbRepository<Crystal> crystals;
        private IDbRepository<ShoppingCart> shoppingCarts;

        public ShoppingCartController(IDbRepository<Crystal> crystals, IDbRepository<ShoppingCart> shoppingCarts)
        {
            this.crystals = crystals;
            this.shoppingCarts = shoppingCarts;
        }

        [HttpGet]
        public ActionResult Add(int id)
        {
            var crystalToAdd = this.crystals.All().FirstOrDefault(x => x.Id == id);

            var currentShoppingCart = this.CartInitializer();

            currentShoppingCart.Crystals.Add(crystalToAdd);

            this.shoppingCarts.Save();

            return this.Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult ListItems()
        {
            var currentShoppingCart = this.CartInitializer();

            var shoppingCartViewModel = new ShoppingCartViewModel()
            {
                Crystals = currentShoppingCart.Crystals,
                Id = currentShoppingCart.Id
            };

            return this.View(shoppingCartViewModel);
        }

        [HttpGet]
        public ActionResult RemoveItem(int id)
        {
            var crystalToRemove = this.crystals.All().FirstOrDefault(x => x.Id == id);
            var currentShoppingCart = this.CartInitializer().Crystals;
            currentShoppingCart.Remove(crystalToRemove);
            this.shoppingCarts.Save();
            return this.RedirectToAction("ListItems");
        }

        private ShoppingCart CartInitializer()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var currentShoppingCart = this.shoppingCarts.All().FirstOrDefault(x => x.UserId == currentUserId);

            if (currentShoppingCart == null)
            {
                currentShoppingCart = new ShoppingCart
                {
                    UserId = currentUserId
                };
                this.shoppingCarts.Add(currentShoppingCart);
            }

            return currentShoppingCart;
        }
    }
}
