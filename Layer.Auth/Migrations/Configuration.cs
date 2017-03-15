namespace Layer.Auth.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AuthDbContext context)
        {
            var defaultUserId = "d69d1135-32d4-41a0-8c1e-18dffd006595";
            var defaultUserName = "default@gmail.com";

            var manager = new CustomUserManager(new UserStore<CustomUser>(context));
            var existedUser = manager.FindById(defaultUserId);

            if (existedUser == null)
            {
                existedUser = new CustomUser() { UserName = defaultUserName, Email = defaultUserName, Id = defaultUserId, EmailConfirmed = true };
                IdentityResult result = manager.Create(existedUser, "Abc123@");
                if (!result.Succeeded)
                {
                    throw new Exception("Create user failed");
                }
            }
        }
    }
}
