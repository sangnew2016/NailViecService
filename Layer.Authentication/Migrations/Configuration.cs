using Layer.Authentication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity.Migrations;

namespace Layer.Authentication.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var defaultUserId = "d69d1135-32d4-41a0-8c1e-18dffd006595";
            var defaultUserName = "sang.thach@orientsoftware.net";

            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var existedUser = manager.FindById(defaultUserId);

            if (existedUser == null)
            {
                existedUser = new ApplicationUser() { UserName = defaultUserName, Email = defaultUserName, Id = defaultUserId, EmailConfirmed = true, Hometown = "VietNam" };
                IdentityResult result = manager.Create(existedUser, "Aa123456!");
                if (!result.Succeeded)
                {
                    throw new Exception("Create user failed");
                }
            }
        }
    }
}
