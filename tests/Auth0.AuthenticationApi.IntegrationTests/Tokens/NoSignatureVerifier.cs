using Auth0.AuthenticationApi.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Auth0.AuthenticationApi.IntegrationTests.Tokens
{
    internal class NoSignatureVerifier : ISignatureVerifier
    {
        private readonly string[] allowedAlgorithms;

        internal NoSignatureVerifier(string[] allowedAlgorithms)
        {
            this.allowedAlgorithms = allowedAlgorithms;
        }

        public Task<JwtSecurityToken> VerifySignatureAsync(string token)
        {
            var securityTokenHandler = new JwtSecurityTokenHandler();

            try
            {
                JwtSecurityToken decoded = securityTokenHandler.ReadJwtToken(token);

                if (allowedAlgorithms.Any() && !allowedAlgorithms.Contains(decoded.Header.Alg))
                {
                    var allowedList = string.Join(", ", allowedAlgorithms.Select(a => "\"" + a + "\""));
                    throw new IdTokenValidationException(
                        $"Signature algorithm of \"{decoded.Header.Alg}\" is not supported. " +
                        $"Expected the ID token to be signed with {allowedList}.");
                }

                return Task.FromResult(decoded);
            }
            catch (ArgumentException e)
            {
                throw new IdTokenValidationException("ID token could not be decoded.", e);
            }
        }
    }
}
