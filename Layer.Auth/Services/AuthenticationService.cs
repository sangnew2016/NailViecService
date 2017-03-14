using Layer.Auth.Models;
using Layer.Auth.Providers;
using Layer.Auth.ServiceData;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Layer.Auth.Services
{
    public class AuthenticationService
    {
        private HttpRequestMessage Request { get; set; }
        private HttpContextBase HttpContext { get; set; }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return Request != null
                    ? Request.GetOwinContext().Authentication
                    : HttpContext.GetOwinContext().Authentication;
            }
        }

        private CustomUserManager _userManager;

        private CustomUserManager UserManager
        {
            get
            {
                if (_userManager != null)
                {
                    return _userManager;
                }

                return Request != null
                    ? Request.GetOwinContext().GetUserManager<CustomUserManager>()
                    : HttpContext.GetOwinContext().GetUserManager<CustomUserManager>();
            }
        }

        public AuthenticationService(HttpRequestMessage request)
        {
            Request = request;
        }

        public AuthenticationService(HttpContextBase httpContext)
        {
            HttpContext = httpContext;
        }

        public AuthenticationService(CustomUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(CustomUser user, string password)
        {
            return await UserManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> CreateUserWithoutPasswordAsync(CustomUser user)
        {
            return await UserManager.CreateAsync(user);
        }

        public IdentityResult DeleteUser(CustomUser user)
        {
            return UserManager.Delete(user);
        }

        public IdentityResult UpdateUser(CustomUser user)
        {
            return UserManager.Update(user);
        }

        public async Task<CustomUser> FindUserAsyncByEmail(string email)
        {
            return await UserManager.FindByNameAsync(email);
        }

        public async Task<CustomUser> FindUserAsync(string email, string password)
        {
            return await UserManager.FindAsync(email, password);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(string userId, string token)
        {
            return await UserManager.ConfirmEmailAsync(userId, token);
        }

        public async Task SignInByExternalLogin(ExternalLoginData externalLogin)
        {
            CustomUser user = await FindUserByExternalLoginAsync(externalLogin);

            if (user != null)
            {
                SignOut();

                ClaimsIdentity oAuthIdentity = await user.GenerateUserIdentityAsync(UserManager,
                    OAuthDefaults.AuthenticationType);
                ClaimsIdentity cookieIdentity = await user.GenerateUserIdentityAsync(UserManager,
                    CookieAuthenticationDefaults.AuthenticationType);

                AuthenticationProperties properties = LayerAuthProvider.CreateProperties(user);
                AuthenticationManager.SignIn(properties, oAuthIdentity, cookieIdentity);
            }
            else
            {
                IEnumerable<Claim> claims = externalLogin.GetClaims();
                ClaimsIdentity identity = new ClaimsIdentity(claims, OAuthDefaults.AuthenticationType);
                AuthenticationManager.SignIn(identity);
            }
        }

        public async Task<IdentityResult> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            return await UserManager.ChangePasswordAsync(userId, oldPassword, newPassword);
        }

        public async Task<IdentityResult> ResetPasswordAsync(string userId, string token, string password)
        {
            return await UserManager.ResetPasswordAsync(userId, token, password);
        }

        public void SignOut()
        {
            var authenticationTypes = AuthenticationManager.GetAuthenticationTypes().Select(x => x.AuthenticationType).Distinct().ToArray();
            AuthenticationManager.SignOut(authenticationTypes);
        }

        public ExternalLoginData GetExternalLoginDataFromIdentity(ClaimsIdentity identity)
        {
            if (identity == null)
            {
                return null;
            }

            Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

            if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                || String.IsNullOrEmpty(providerKeyClaim.Value))
            {
                return null;
            }

            if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
            {
                return null;
            }

            return new ExternalLoginData
            {
                LoginProvider = providerKeyClaim.Issuer,
                ProviderKey = providerKeyClaim.Value,
                UserName = identity.FindFirstValue(ClaimTypes.Name)
            };
        }

        public async Task<CustomUser> FindUserByExternalLoginAsync(ExternalLoginData externalLoginData)
        {
            return await UserManager.FindAsync(new UserLoginInfo(externalLoginData.LoginProvider,
                externalLoginData.ProviderKey));
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(CustomUser user)
        {
            return await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(CustomUser user)
        {
            return await UserManager.GeneratePasswordResetTokenAsync(user.Id);
        }

        public async Task<bool> IsEmailConfirmedAsync(string userId)
        {
            return await UserManager.IsEmailConfirmedAsync(userId);
        }

        public async Task SendEmailAsync(string userId, string subject, string body)
        {
            await UserManager.SendEmailAsync(userId, subject, body);
        }
    }
}
