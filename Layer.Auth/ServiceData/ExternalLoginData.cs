using System.Collections.Generic;
using System.Security.Claims;

namespace Layer.Auth.ServiceData
{
    public class ExternalLoginData
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string UserName { get; set; }

        public IList<Claim> GetClaims()
        {
            IList<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

            if (UserName != null)
            {
                claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
            }

            return claims;
        }
    }
}
