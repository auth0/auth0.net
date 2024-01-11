using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;

namespace Auth0.AuthenticationApi.Tokens
{
    internal abstract class SignedDecoder
    {
        readonly JwtSignatureAlgorithm signatureAlgorithm;
        readonly JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
        readonly TokenValidationParameters validationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateActor = false,
            ValidateLifetime = false,
            ValidateTokenReplay = false,
            RequireSignedTokens = true,
            ValidateIssuerSigningKey = true
        };

        protected SignedDecoder(JwtSignatureAlgorithm signatureAlgorithm, IEnumerable<SecurityKey> keys)
        {
            this.signatureAlgorithm = signatureAlgorithm;
            validationParameters.IssuerSigningKeys = keys;
        }

        public JwtSecurityToken DecodeSignedToken(string token)
        {
            AssertTokenAlgorithm(token);

            try
            {
                securityTokenHandler.ValidateToken(token, validationParameters, out var verifiedToken);
                return (JwtSecurityToken)verifiedToken;
            }
            catch (SecurityTokenSignatureKeyNotFoundException ex)
            {
                if (signatureAlgorithm == JwtSignatureAlgorithm.HS256)
                {
                    throw new IdTokenValidationException("Invalid token signature.", ex);
                }
                throw new IdTokenValidationKeyMissingException("Token signature key could not be found", ex);
            }
            catch (SecurityTokenException ex)
            {
                throw new IdTokenValidationException("Invalid token signature.", ex);
            }
        }

        private void AssertTokenAlgorithm(string token)
        {
            try
            {
                var decoded = securityTokenHandler.ReadJwtToken(token);
                if (decoded.SignatureAlgorithm != signatureAlgorithm.ToString())
                    throw new IdTokenValidationException($"Signature algorithm of \"{decoded.Header.Alg }\" is not supported. Expected the ID token to be signed with \"{signatureAlgorithm.ToString()}\".");
            }
            catch (ArgumentException e)
            {
                throw new IdTokenValidationException("ID token could not be decoded.", e);
            }
        }
    }
}