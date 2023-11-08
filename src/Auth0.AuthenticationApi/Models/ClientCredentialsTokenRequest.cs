using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request get a token using the Client Credentials Grant flow.
    /// </summary>
    public class ClientCredentialsTokenRequest : IClientAuthentication
    {
        /// <summary>
        /// Unique identifier of the target API to access.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Client ID of the application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Client Secret of the application.
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
        /// What <see cref="JwtSignatureAlgorithm"/> is used to verify the signature
        /// of Id Tokens.
        /// </summary>
        public JwtSignatureAlgorithm SigningAlgorithm { get; set; }
        
        /// <summary>
        /// Organization.
        /// </summary>
        /// <remarks>
        /// This can be an Organization Name or ID. When included, the access token returned will include the org_id and org_name claims
        /// </remarks>
        public string Organization { get; set; }
    }
}