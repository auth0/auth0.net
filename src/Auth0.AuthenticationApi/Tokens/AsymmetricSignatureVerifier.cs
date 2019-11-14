using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.Tokens
{
    internal class AsymmetricSignatureVerifier : ISignatureVerifier
    {
        private readonly IList<JsonWebKey> keys;

        public static async Task<AsymmetricSignatureVerifier> ForJwks(string issuer)
        {
            var jsonWebKeys = await JsonWebKeys.GetForIssuer(issuer);
            return new AsymmetricSignatureVerifier(jsonWebKeys.Keys);
        }

        public AsymmetricSignatureVerifier(IList<JsonWebKey> keys)
        {
            this.keys = keys;
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

            if (decoded.SignatureAlgorithm != "RS256")
                throw new IdTokenValidationException($"Signature algorithm of \"{decoded.Header.Alg }\" is not supported. Expected the ID token to be signed with \"RS256\".");

            var publicKey = FindPublicKeyByKid(decoded.Header.Kid);

            return (JwtSecurityToken) ValidateTokenSignatureWithKey(token, securityTokenHandler, publicKey);
        }

        internal static SecurityToken ValidateTokenSignatureWithKey(string token, JwtSecurityTokenHandler securityTokenHandler, JsonWebKey key)
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
                    IssuerSigningKey = key,
                };

                securityTokenHandler.ValidateToken(token, validationParameters, out var verifiedToken);
                return verifiedToken;
            }
            catch (SecurityTokenException e)
            {
                throw new IdTokenValidationException("Invalid ID token signature.", e);
            }
        }

        private JsonWebKey FindPublicKeyByKid(string kid)
        {
            var key = keys.FirstOrDefault(k => k.Kid == kid);
            if (key == null)
                throw new IdTokenValidationException($"Could not find a public key for Key ID (kid) \"{kid}\".");

            return key;
        }
    }
}
