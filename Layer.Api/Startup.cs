using Layer.Auth;
using Owin;
using System.Web.Http;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace Layer.Api
{
    public class Startup: AuthConfig
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();

            ConfigureOAuthTokenGeneration(app);

            ConfigureOAuthTokenConsumption(app);

            ConfigureWebApi(httpConfig);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(httpConfig);

        }
    }
}