namespace OnlineCrystalStore.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using OnlineCrystalStore.Data.Common;
    using OnlineCrystalStore.Data.Models;
    using OnlineCrystalStore.Web.Controllers;
    using ViewModels.Crystal;

    public class CrystalController : BaseController
    {
        private IDbRepository<Crystal> crystals;

        public CrystalController(IDbRepository<Crystal> crystals)
        {
            this.crystals = crystals;
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CrystalViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var crystal = new Crystal()
            {
                Price = model.Price
            };

            this.crystals.Add(crystal);
            this.crystals.Save();
            return this.Redirect("/");
        }
    }
}
