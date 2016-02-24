namespace OnlineCrystalStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using OnlineCrystalStore.Data.Common;
    using OnlineCrystalStore.Data.Models;
    using OnlineCrystalStore.Web.Controllers;
    using ViewModels.OrderDetails;

    public class OrderDetailsController : BaseController
    {
        private IDbRepository<OrderDetails> orders;
        private IDbRepository<ShoppingCart> shoppingCarts;
        private IDbRepository<Crystal> crystals;

        public OrderDetailsController(
                            IDbRepository<OrderDetails> orders,
                            IDbRepository<ShoppingCart> shoppingCarts,
                            IDbRepository<Crystal> crystals)
        {
            this.orders = orders;
            this.shoppingCarts = shoppingCarts;
            this.crystals = crystals;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderDetailsViewModel model, int id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var newOrder = new OrderDetails()
            {
                Id = model.Id,
                Address = model.Address,
                BuyerId = this.User.Identity.GetUserId(),
                City = model.City,
                Country = model.Country,
                ShoppingCartId = id,
                PaymentMethod = model.PaymentMethod
            };
            var currentShoppingCart = this.shoppingCarts.All().FirstOrDefault(x => x.Id == id);
            newOrder.TotalPrice = currentShoppingCart.Crystals.Sum(x => x.Price);

            this.orders.Add(newOrder);
            this.orders.Save();

            foreach (var item in currentShoppingCart.Crystals)
            {
                this.crystals.Delete(item);
            }

            this.shoppingCarts.Delete(currentShoppingCart);
            this.crystals.Save();
            this.shoppingCarts.Save();

            return this.Redirect("/Home/Index");
        }

        // admin
        // list
    }
}
