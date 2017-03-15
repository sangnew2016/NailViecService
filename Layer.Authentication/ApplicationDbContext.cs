using Layer.Authentication.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Layer.Authentication
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("NailViecAuthContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
