
using System;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JWTAuthDemo
{
    public static class JwtConfig
    {
        // Secret key for signing JWT (keep this safe in production!)
        public static string SecretKey = "asdfasdfasdfasdfasdfasdfasdfasdfasdfasdfasdf";

        // Issuer: who issues the token
        public static string Issuer = "JwtAuth";

        // Audience: who the token is valid for
        public static string Audience = "JwtUsers";

        // Token expiration time in minutes
        public static int TokenExpirationMinutes = 30;

        // SymmetricSecurityKey object for signing
        public static SymmetricSecurityKey SigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
    }

}