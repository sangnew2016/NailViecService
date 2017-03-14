using Layer.Auth.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Layer.Auth
{
    public class AuthDbContext : IdentityDbContext<CustomUser>
    {
        public AuthDbContext(): base("NailViecAuthContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<AuthDbContext, Migrations.Configuration>());
        }

        public AuthDbContext(string connectionString)
            : base(connectionString)
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<AuthDbContext, Migrations.Configuration>());
        }

        public static AuthDbContext Create(string connectionString)
        {
            return new AuthDbContext(connectionString);
        }
    }
}
