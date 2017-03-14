using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.IdentityModel.Tokens;
using Thinktecture.IdentityModel.Tokens;

namespace Layer.Auth.Providers
{
    internal class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string _issuer = string.Empty;
        private readonly string _audienceId = string.Empty;
        private readonly string _symmetricKeyAsBase64 = string.Empty;

        public CustomJwtFormat(string issuer, string audienceId, string symmetricKeyAsBase64)
        {
            _issuer = issuer;
            _audienceId = audienceId;
            _symmetricKeyAsBase64 = symmetricKeyAsBase64;
        }

        public string Protect(AuthenticationTicket data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            var keyByteArray = TextEncodings.Base64Url.Decode(_symmetricKeyAsBase64);

            var signingKey = new HmacSigningCredentials(keyByteArray);

            var issued = data.Properties.IssuedUtc;

            var expires = data.Properties.ExpiresUtc;

            var token = new JwtSecurityToken(_issuer, _audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime, signingKey);

            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.WriteToken(token);

            return jwt;
        }

        public AuthenticationTicket Unprotect(string protectedText)
        {
            if (protectedText == null) throw new ArgumentNullException("protectedText");
            return new AuthenticationTicket(new System.Security.Claims.ClaimsIdentity(), new AuthenticationProperties());
        }
    }
}
