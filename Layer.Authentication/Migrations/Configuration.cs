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
            CreateRolesandUsers(context);
        }

        private void CreateRolesandUsers(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // In Startup iam creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists("Admin"))
            {
                // first we create Admin rool
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Here we create a Admin super user who will maintain the website
                var defaultUserId = "d69d1135-32d4-41a0-8c1e-18dffd006595";
                var defaultUserName = "sang.thach@orientsoftware.net";
                var existedUser = UserManager.FindById(defaultUserId);
                if (existedUser == null)
                {
                    existedUser = new ApplicationUser() { UserName = defaultUserName, Email = defaultUserName, Id = defaultUserId, EmailConfirmed = true, Hometown = "VietNam" };
                    IdentityResult addingUserResult = UserManager.Create(existedUser, "Aa123456!");
                    if (!addingUserResult.Succeeded)
                    {
                        throw new Exception("Create user failed");
                    }

                    var addingUserToRole = UserManager.AddToRole(existedUser.Id, "Admin");
                    if (!addingUserToRole.Succeeded)
                    {
                        throw new Exception("Add user to role Admin failed");
                    }
                }
            }

            // creating Creating Manager role
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            // creating Creating Employee role
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);
            }
        }
    }
}
