namespace OnlineCrystalStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Data.Models;
    using Data.Common;
    using ViewModels.Home;
    public class HomeController : BaseController
    {
        private IDbRepository<Crystal> crystals;

        public HomeController(IDbRepository<Crystal> crystals)
        {
            this.crystals = crystals;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var allCrystals = this.crystals.All().OrderBy(x => x.Price)
                .To<IndexViewModel>();

            return this.View(allCrystals);
        }

        [HttpGet]
        public ActionResult AboutUs()
        {
            return this.View();
        }
    }
}
