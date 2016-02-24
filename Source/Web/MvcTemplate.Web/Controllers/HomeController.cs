namespace OnlineCrystalStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Common;
    using Data.Models;
    using Infrastructure.Mapping;
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
            var allCrystals = this.crystals.All().Where(x => x.IsSold == false).OrderBy(x => x.Price)
                .To<IndexViewModel>().ToList();

            return this.View(allCrystals);
        }

        [HttpGet]
        public ActionResult AboutUs()
        {
            return this.View();
        }
    }
}
