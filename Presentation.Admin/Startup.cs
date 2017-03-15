using Layer.Authentication;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Presentation.Admin.Startup))]

namespace Presentation.Admin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new AuthStartupConfig();
            config.ConfigureAuth(app);
        }
    }
}
