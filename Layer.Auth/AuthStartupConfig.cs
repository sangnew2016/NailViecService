using Layer.Auth.Providers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

namespace Layer.Auth
{
    public class AuthStartupConfig
    {
        public AuthStartupConfig()
        {
            ConnectionString = "";
            AccessTokenExpireTimeSpanFromDays = 7;
            TokenEndpointPath = "/Token";
            AuthorizeEndpointPath = "/Authorize";
            AccessTokenIssuer = string.Empty;
            AudienceId = string.Empty;
            AudienceSecret = string.Empty;
            Provider = new LayerAuthProvider("");
        }

        private static OAuthAuthorizationServerOptions OAuthServerOptions { get; set; }

        public string ConnectionString { get; set; }
        public double AccessTokenExpireTimeSpanFromDays { get; set; }
        public string TokenEndpointPath { get; set; }
        public string AuthorizeEndpointPath { get; set; }
        public string AccessTokenIssuer { get; set; }
        public string AudienceId { get; set; }
        public string AudienceSecret { get; set; }
        public LayerAuthProvider Provider { get; set; }


        public static void UseLayerAuth(IAppBuilder app, AuthStartupConfig config)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            ConfigureOAuthTokenGeneration(app, config);

            ConfigureOAuthTokenConsumption(app, config);
        }

        private static void ConfigureOAuthTokenGeneration(IAppBuilder app, AuthStartupConfig config)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(() => AuthDbContext.Create(config.ConnectionString));
            app.CreatePerOwinContext<CustomUserManager>(CustomUserManager.Create);

            //Use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            OAuthServerOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString(config.TokenEndpointPath),
                Provider = config.Provider,
                AuthorizeEndpointPath = new PathString(config.AuthorizeEndpointPath),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(config.AccessTokenExpireTimeSpanFromDays),
                AllowInsecureHttp = true,
                AccessTokenFormat = new CustomJwtFormat(config.AccessTokenIssuer, config.AudienceId, config.AudienceSecret)
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthServerOptions);
        }

        private static void ConfigureOAuthTokenConsumption(IAppBuilder app, AuthStartupConfig config)
        {
            byte[] audienceSecretBytes = TextEncodings.Base64Url.Decode(config.AudienceSecret);

            // Api controllers with an [Authorize] attribute will be validated with JWT
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    AllowedAudiences = new[] { config.AudienceId },
                    IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider(config.AccessTokenIssuer, audienceSecretBytes)
                    }
                });
        }
    }
}
