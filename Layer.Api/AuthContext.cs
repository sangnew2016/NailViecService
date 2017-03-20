using Microsoft.AspNet.Identity.EntityFramework;

namespace Layer.Api
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : base("NailViecAuthContext")
        {

        }
    }
}