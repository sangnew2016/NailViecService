using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Security.Cryptography;

namespace Layer.Auth.Utils
{
    internal static class KeyGenerator
    {
        public static KeyPair CreateNew()
        {
            var publicKey = Guid.NewGuid().ToString();

            var key = new byte[32];
            RandomNumberGenerator.Create().GetBytes(key);
            var base64SecretKey = TextEncodings.Base64Url.Encode(key);

            return new KeyPair(publicKey, base64SecretKey);
        }
    }

    internal class KeyPair
    {
        public KeyPair(string publicKey, string secretKey)
        {
            PublicKey = publicKey;
            SecretKey = secretKey;
        }

        public string PublicKey { get; set; }
        public string SecretKey { get; set; }
    }
}
