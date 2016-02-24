namespace OnlineCrystalStore.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using OnlineCrystalStore.Common;
    using OnlineCrystalStore.Data;
    using OnlineCrystalStore.Data.Common;
    using OnlineCrystalStore.Data.Models;
    using OnlineCrystalStore.Web.Areas.Administration.ViewModels;
    using OnlineCrystalStore.Web.Infrastructure.Mapping;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class OrderController : Controller
    {
        private IDbRepository<OrderDetails> orders;

        public OrderController(IDbRepository<OrderDetails> orders)
        {
            this.orders = orders;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult OrderDetails_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.orders.AllWithDeleted()
               .To<OrderViewModel>()
               .ToDataSourceResult(request);
            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderDetails_Update([DataSourceRequest]DataSourceRequest request, OrderInputModel orderDetails)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.orders.GetById(orderDetails.Id);

                entity.Address = orderDetails.Address;
                entity.City = orderDetails.City;
                entity.Country = orderDetails.Country;

                this.orders.Save();
            }

            var orderToDisplay = this.orders.AllWithDeleted().To<OrderViewModel>().FirstOrDefault(x => x.Id == orderDetails.Id);
            return this.Json(new[] { orderDetails }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult OrderDetails_Destroy([DataSourceRequest]DataSourceRequest request, OrderDetails orderDetails)
        {
            var entity = this.orders.All().FirstOrDefault(x => x.Id == orderDetails.Id);
            this.orders.Delete(entity);
            this.orders.Save();

            return this.Json(new[] { orderDetails }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return this.File(fileContents, contentType, fileName);
        }
    }
}
