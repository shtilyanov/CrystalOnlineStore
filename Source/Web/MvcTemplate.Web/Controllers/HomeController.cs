namespace OnlineCrystalStore.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    public class HomeController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult AboutUs()
        {
            return this.View();
        }
    }
}
