using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class SymmetricSignatureVerifier : ISignatureVerifier
    {
        private readonly SecurityKey signingKey;

        public SymmetricSignatureVerifier(SecurityKey signingKey)
        {
            this.signingKey = signingKey;
        }

        public static SymmetricSignatureVerifier FromClientSecret(string clientSecret, bool isBase64Encoded = false)
        {
            var keyBytes = isBase64Encoded ? Convert.FromBase64String(clientSecret) : Encoding.ASCII.GetBytes(clientSecret);
            return new SymmetricSignatureVerifier(new SymmetricSecurityKey(keyBytes));
        }

        public JwtSecurityToken VerifySignature(string token)
        {
            var securityTokenHandler = new JwtSecurityTokenHandler();

            JwtSecurityToken decoded;
            try
            {
                decoded = securityTokenHandler.ReadJwtToken(token);
            }
            catch (ArgumentException e)
            {
                throw new IdTokenValidationException("ID token could not be decoded.", e);
            }

            if (decoded.SignatureAlgorithm != "HS256")
                throw new IdTokenValidationException($"Signature algorithm of \"{decoded.Header.Alg }\" is not supported. Expected the ID token to be signed with \"HS256\".");

            return (JwtSecurityToken)ValidateTokenSignatureWithKey(token, securityTokenHandler);
        }

        internal SecurityToken ValidateTokenSignatureWithKey(string token, JwtSecurityTokenHandler securityTokenHandler)
        {
            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateActor = false,
                    ValidateLifetime = false,
                    ValidateTokenReplay = false,

                    RequireSignedTokens = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey
                };

                securityTokenHandler.ValidateToken(token, validationParameters, out var verifiedToken);
                return verifiedToken;
            }
            catch (SecurityTokenException e)
            {
                throw new IdTokenValidationException("Invalid ID token signature.", e);
            }
        }
    }
}
