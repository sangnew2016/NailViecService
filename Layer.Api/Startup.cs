using System;
using Microsoft.Owin;
using Owin;
using Layer.Auth;
using System.Configuration;
using Layer.Auth.Providers;
using Layer.Domain.Resources;

[assembly: OwinStartup(typeof(Layer.Api.Startup))]

namespace Layer.Api
{
    public partial class Startup
    {

        public static AuthStartupConfig AuthStartupConfig { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            ConfigurationAuth(app);
        }

        public void ConfigurationAuth(IAppBuilder app)
        {
            PublicClientId = "Layer.Auth";
            AuthStartupConfig = new AuthStartupConfig
            {
                AccessTokenExpireTimeSpanFromDays = Convert.ToDouble(ConfigurationManager.AppSettings["TokenExpireTimeDays"]),
                TokenEndpointPath = "/api/authentication/login",
                AuthorizeEndpointPath = "/api/authentication/externalLogin",
                AccessTokenIssuer = ConfigurationManager.AppSettings["CandidateAppApiDomain"],
                AudienceId = ConfigurationManager.AppSettings["as:AudienceId"],
                AudienceSecret = ConfigurationManager.AppSettings["as:AudienceSecret"],
                ConnectionString = ConfigurationManager.AppSettings["AuthConnectionStringName"],
                Provider = new LayerAuthProvider(PublicClientId)
                {
                    ErrorEmailNotConfirmed =
                        new LayerAuthProvider.Error(AppResourceKey.ErrorEmailNotConfirmed,
                            ResourceManager.GetString(AppResourceKey.ErrorEmailNotConfirmed)),
                    ErrorInvalidUserNameOrPassword =
                        new LayerAuthProvider.Error(AppResourceKey.ErrorInvalidUserNameOrPassword,
                            ResourceManager.GetString(AppResourceKey.ErrorInvalidUserNameOrPassword))
                }
            };

            AuthStartupConfig.UseLayerAuth(app, AuthStartupConfig);
        }
    }
}
