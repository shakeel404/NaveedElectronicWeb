using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NaveedElectronicWeb.Startup))]
namespace NaveedElectronicWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
