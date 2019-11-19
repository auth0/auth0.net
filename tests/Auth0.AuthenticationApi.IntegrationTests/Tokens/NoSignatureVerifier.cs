using Auth0.AuthenticationApi.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Auth0.AuthenticationApi.IntegrationTests.Tokens
{
    internal class NoSignatureVerifier : ISignatureVerifier
    {
        private readonly string[] allowedAlgorithms;

        internal NoSignatureVerifier(string[] allowedAlgorithms)
        {
            this.allowedAlgorithms = allowedAlgorithms;
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

            if (allowedAlgorithms.Any() && !allowedAlgorithms.Contains(decoded.Header.Alg))
            {
                var allowedList = String.Join(", ", allowedAlgorithms.Select(a => "\"" + a + "\""));
                throw new IdTokenValidationException(
                    $"Signature algorithm of \"{decoded.Header.Alg}\" is not supported. " +
                    $"Expected the ID token to be signed with {allowedList}.");
            }

            return decoded;
        }
    }
}
