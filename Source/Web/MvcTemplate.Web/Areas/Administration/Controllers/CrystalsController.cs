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
using OnlineCrystalStore.Data.Models;
using OnlineCrystalStore.Data;
using OnlineCrystalStore.Data.Common;
using OnlineCrystalStore.Web.Areas.Administration.ViewModels;
using OnlineCrystalStore.Web.Infrastructure.Mapping;
using OnlineCrystalStore.Common;

namespace OnlineCrystalStore.Web.Areas.Administration.Controllers
{
    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class CrystalsController : Controller
    {
        private IDbRepository<Crystal> crystals;

        public CrystalsController(IDbRepository<Crystal> crystals)
        {
            this.crystals = crystals;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Crystals_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.crystals.AllWithDeleted()
               .To<CrystalVewModel>()
               .ToDataSourceResult(request);
            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Crystals_Update([DataSourceRequest]DataSourceRequest request, CrystalVewModel crystal)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.crystals.GetById(crystal.Id);

                entity.Name = crystal.Name;
                entity.Price = crystal.Price;
                entity.Size = crystal.Size;
                entity.Weight = crystal.Weight;

                this.crystals.Save();
            }

            var orderToDisplay = this.crystals.AllWithDeleted().To<CrystalVewModel>().FirstOrDefault(x => x.Id == crystal.Id);

            return Json(new[] { crystal }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Crystals_Destroy([DataSourceRequest]DataSourceRequest request, Crystal crystal)
        {
            var entity = this.crystals.All().FirstOrDefault(x => x.Id == crystal.Id);
            this.crystals.Delete(entity);
            this.crystals.Save();

            return this.Json(new[] { crystal }.ToDataSourceResult(request, ModelState));
        }

        [HttpPost]
        public ActionResult Excel_Export_Save(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }
    }
}
