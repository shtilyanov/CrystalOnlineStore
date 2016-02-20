namespace OnlineCrystalStore.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using OnlineCrystalStore.Common;
    using OnlineCrystalStore.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    public class AdministrationController : BaseController
    {
    }
}
