using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BSG.WebUI.Startup))]
namespace BSG.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
