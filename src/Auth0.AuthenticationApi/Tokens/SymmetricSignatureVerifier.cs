using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class SymmetricSignatureVerifier : ISignatureVerifier
    {
        readonly SecurityKey signingKey;

        public SymmetricSignatureVerifier(SecurityKey signingKey)
        {
            this.signingKey = signingKey;
        }

        public static SymmetricSignatureVerifier FromClientSecret(string clientSecret)
        {
            return new SymmetricSignatureVerifier(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(clientSecret)));
        }

        public Task<JwtSecurityToken> VerifySignatureAsync(string token)
        {
            var securityTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var decoded = securityTokenHandler.ReadJwtToken(token);
                if (decoded.SignatureAlgorithm != "HS256")
                    throw new IdTokenValidationException($"Signature algorithm of \"{decoded.Header.Alg }\" is not supported. Expected the ID token to be signed with \"HS256\".");
            }
            catch (ArgumentException e)
            {
                throw new IdTokenValidationException("ID token could not be decoded.", e);
            }

            return Task.FromResult(ValidateTokenSignatureWithKey(token, securityTokenHandler));
        }

        internal JwtSecurityToken ValidateTokenSignatureWithKey(string token, JwtSecurityTokenHandler securityTokenHandler)
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
                return (JwtSecurityToken)verifiedToken;
            }
            catch (SecurityTokenException e)
            {
                throw new IdTokenValidationException("Invalid token signature.", e);
            }
        }
    }
}
