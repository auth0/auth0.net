using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to get new tokens based on a previously obtained refresh token.
    /// </summary>
    public class RevokeRefreshTokenRequest : IClientAuthentication
    {
        /// <summary>
        /// Security Key to use with Client Assertion
        /// </summary>
        public SecurityKey ClientAssertionSecurityKey { get; set; }

        /// <summary>
        /// Algorithm for the Security Key to use with Client Assertion
        /// </summary>
        public string ClientAssertionSecurityKeyAlgorithm { get; set; }

        /// <summary>
        /// Client ID for which the refresh token was issued.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Client secret for which the refresh token was issued.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// A refresh token you want to revoke.
        /// </summary>
        public string RefreshToken { get; set; }
    }
}
