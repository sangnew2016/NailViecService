using Layer.Auth.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Layer.Auth.Providers
{
    public class LayerAuthProvider : OAuthAuthorizationServerProvider
    {
        private readonly string _publicClientId;
        public static readonly string JwtAuthenticationType = "JWT";

        public LayerAuthProvider(string publicClientId)
        {
            if (publicClientId == null)
            {
                throw new ArgumentNullException("publicClientId");
            }

            _publicClientId = publicClientId;
            ErrorInvalidUserNameOrPassword = new Error("ERROR_INVALID_USER_NAME_OR_PASSWORD", "The user name or password is incorrect.");
            ErrorEmailNotConfirmed = new Error("ERROR_EMAIL_NOT_CONFIRMED", "This email hasn't been confirmed yet.");
        }

        public Error ErrorInvalidUserNameOrPassword { get; set; }
        public Error ErrorEmailNotConfirmed { get; set; }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var userManager = context.OwinContext.GetUserManager<CustomUserManager>();
            var user = await userManager.FindAsync(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError(ErrorInvalidUserNameOrPassword.Key, ErrorInvalidUserNameOrPassword.Description);
                return;
            }

            if (user.EmailConfirmed == false)
            {
                context.SetError(ErrorEmailNotConfirmed.Key, ErrorEmailNotConfirmed.Description);
                return;
            }

            ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(userManager, OAuthDefaults.AuthenticationType);

            //Validate the token to make it available to login
            AuthenticationTicket ticket = new AuthenticationTicket(oAuthIdentity, CreateProperties(user));
            context.Validated(ticket);

            //To return the token
            context.Request.Context.Authentication.SignIn(oAuthIdentity);
            if (context.HasError == false && context.IsValidated)
            {
                user.LatestLoginDate = DateTime.Now;
                await userManager.UpdateAsync(user);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            // Resource owner password credentials does not provide a client ID.
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task ValidateClientRedirectUri(OAuthValidateClientRedirectUriContext context)
        {
            if (context.ClientId == _publicClientId)
            {
                Uri expectedRootUri = new Uri(context.Request.Uri, "/");

                if (expectedRootUri.AbsoluteUri == context.RedirectUri)
                {
                    context.Validated();
                }
            }

            return Task.FromResult<object>(null);
        }

        public static AuthenticationProperties CreateProperties(CustomUser user)
        {
            IDictionary<string, string> data = new Dictionary<string, string>
            {
                { "userName", user.UserName },
                { "LatestLoginDate", user.LatestLoginDate.HasValue ? user.LatestLoginDate.ToString() : null },
            };
            return new AuthenticationProperties(data);
        }

        public class Error
        {
            public Error(string key, string description)
            {
                Key = key;
                Description = description;
            }

            public string Key { get; set; }
            public string Description { get; set; }
        }
    }
}
