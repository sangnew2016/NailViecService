using Layer.Authentication;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Layer.Api.Startup))]

namespace Layer.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new AuthStartupConfig();
            config.ConfigureAuth(app);
        }
    }
}
