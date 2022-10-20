using Auth0.AuthenticationApi.Tokens;
using Microsoft.IdentityModel.Protocols;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi
{
    internal class IdTokenValidator
    {
        readonly TimeSpan maxJwksKeySetValidFor = TimeSpan.FromMinutes(10);
        readonly TimeSpan minJwksRefreshInterval = TimeSpan.FromSeconds(15);
        readonly JsonWebKeyCache jsonWebKeyCache;

        public IdTokenValidator(IDocumentRetriever openIdConnectDocumentRetriever = null)
        {
            jsonWebKeyCache = new JsonWebKeyCache(new JsonWebKeys(openIdConnectDocumentRetriever));
        }

        public async Task Assert(IdTokenRequirements requirements, string idToken, string clientSecret, DateTime? pointInTime = null)
        {
            if (string.IsNullOrWhiteSpace(idToken))
                throw new IdTokenValidationException("ID token is required but missing.");

            var verifiedToken = await DecodeSignedToken(requirements, idToken, clientSecret).ConfigureAwait(false);
            IdTokenClaimValidator.AssertClaimsMeetRequirements(requirements, verifiedToken, pointInTime ?? DateTime.Now);
        }

        private Task<JwtSecurityToken> DecodeSignedToken(IdTokenRequirements requirements, string idToken, string clientSecret)
        {
            switch (requirements.SignatureAlgorithm)
            {
                case JwtSignatureAlgorithm.HS256:
                    return Task.FromResult(new SymmetricSignedDecoder(clientSecret).DecodeSignedToken(idToken));

                case JwtSignatureAlgorithm.RS256:
                    try
                    {
                        return AssertRS256IdTokenValid(idToken, requirements.Issuer, maxJwksKeySetValidFor);
                    }
                    catch (IdTokenValidationKeyMissingException)
                    {
                        return AssertRS256IdTokenValid(idToken, requirements.Issuer, minJwksRefreshInterval);
                    }

                default:
                    throw new ArgumentOutOfRangeException($"SignatureAlgorithm '{requirements.SignatureAlgorithm}' not supported.", nameof(requirements));
            }
        }

        private async Task<JwtSecurityToken> AssertRS256IdTokenValid(string idToken, string issuer, TimeSpan maxAge)
        {
            var keys = await jsonWebKeyCache.Get(issuer, maxAge).ConfigureAwait(false);
            return new AsymmetricSignedDecoder(keys.Keys).DecodeSignedToken(idToken);
        }
    }
}
