using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request get a token using the Resource Owner Grant flow.
    /// </summary>
    public class ResourceOwnerTokenRequest : IClientAuthentication
    {
        /// <summary>
        /// Optional unique identifier of the target API to access.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Client ID of the application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Optional client secret of the application.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Security Key to use with Client Assertion
        /// </summary>
        public SecurityKey ClientAssertionSecurityKey { get; set; }

        /// <summary>
        /// Algorithm for the Security Key to use with Client Assertion
        /// </summary>
        public string ClientAssertionSecurityKeyAlgorithm { get; set; }

        /// <summary>
        /// Optional realm the user belongs to.
        /// </summary>
        /// <remarks>
        /// See https://auth0.com/docs/api-auth/grant/password#realm-support for more details.
        /// </remarks>
        public string Realm { get; set; }

        /// <summary>
        /// Resource Owner's secret.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Optional scopes to be requested. Separate multiple values with a space.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Resource Owner's identifier.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// IP address of the end user this token is requested for.
        /// </summary>
        /// <remarks>
        /// It is important to set this if using this API server-side.
        /// See https://auth0.com/docs/api-auth/tutorials/using-resource-owner-password-from-server-side for more details.
        /// </remarks>
        public string ForwardedForIp { get; set; }

        /// <summary>
        /// What <see cref="JwtSignatureAlgorithm"/> is used to verify the signature
        /// of Id Tokens.
        /// </summary>
        public JwtSignatureAlgorithm SigningAlgorithm { get; set; }
    }
}