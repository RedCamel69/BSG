using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BSG.Startup))]
namespace BSG
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
