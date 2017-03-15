using Layer.Auth.Models;
using Layer.Auth.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;

namespace Layer.Auth
{
    public class CustomUserManager : UserManager<CustomUser>
    {
        public CustomUserManager(IUserStore<CustomUser> store): base(store)
        {
        }

        public static CustomUserManager Create(IdentityFactoryOptions<CustomUserManager> options, IOwinContext context)
        {
            var manager = new CustomUserManager(new UserStore<CustomUser>(context.Get<AuthDbContext>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<CustomUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            //Configure email service
            manager.EmailService = new EmailService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<CustomUser>(dataProtectionProvider.Create("Layer.Auth"))
                {
                    TokenLifespan = TimeSpan.FromDays(999999)
                };
            }
            return manager;
        }
    }
}
