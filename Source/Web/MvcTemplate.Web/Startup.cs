using Microsoft.Owin;

using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineCrystalStore.Web.Startup))]

namespace OnlineCrystalStore.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
