using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class AsymmetricSignatureVerifier : ISignatureVerifier
    {
        readonly IList<JsonWebKey> keys;

        public static async Task<AsymmetricSignatureVerifier> ForJwks(string issuer)
        {
            var jsonWebKeys = await JsonWebKeys.GetForIssuer(issuer);
            return new AsymmetricSignatureVerifier(jsonWebKeys.Keys);
        }

        public AsymmetricSignatureVerifier(IList<JsonWebKey> keys)
        {
            this.keys = keys;
        }

        public Task<JwtSecurityToken> VerifySignatureAsync(string token)
        {
            var securityTokenHandler = new JwtSecurityTokenHandler();
            var kid = GetTokenKid(token, securityTokenHandler);
            return Task.FromResult(ValidateTokenSignature(token, securityTokenHandler, kid, keys));
        }

        internal static string GetTokenKid(string token, JwtSecurityTokenHandler securityTokenHandler)
        {
            try
            {
                var decoded = securityTokenHandler.ReadJwtToken(token);
                if (decoded.SignatureAlgorithm != "RS256")
                    throw new IdTokenValidationException($"Signature algorithm of \"{decoded.Header.Alg }\" is not supported. Expected the ID token to be signed with \"RS256\".");
                return decoded.Header.Kid;
            }
            catch (ArgumentException e)
            {
                throw new IdTokenValidationException("ID token could not be decoded.", e);
            }
        }

        internal static JwtSecurityToken ValidateTokenSignature(string token, JwtSecurityTokenHandler securityTokenHandler, string kid, IList<JsonWebKey> keys)
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
                    IssuerSigningKeys = keys,
                };

                securityTokenHandler.ValidateToken(token, validationParameters, out var verifiedToken);
                return (JwtSecurityToken)verifiedToken;
            }
            catch (SecurityTokenSignatureKeyNotFoundException)
            {
                throw new IdTokenValidationException($"Could not find a public key for Key ID (kid) \"{kid}\".");
            }
            catch (SecurityTokenException e)
            {
                throw new IdTokenValidationException("Invalid token signature.", e);
            }
        }
    }
}