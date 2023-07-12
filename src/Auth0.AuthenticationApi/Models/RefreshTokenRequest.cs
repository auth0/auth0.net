using Microsoft.IdentityModel.Tokens;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to get new tokens based on a previously obtained refresh token.
    /// </summary>
    public class RefreshTokenRequest : IClientAuthentication
    {
        /// <summary>
        /// Optional audience used for refreshing the access token token.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// A valid refresh token previously issued to the client.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Optional scope for the access request.
        /// </summary>
        /// <remarks>
        /// The requested scope must not include any scope not originally granted
        /// by the resource owner, and if omitted is treated as equal to the scope
        /// originally granted by the resource owner.
        /// </remarks>
        public string Scope { get; set; }

        /// <summary>
        /// Client ID for which the refresh token was issued.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Client secret for which the refresh token was issued.
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
        /// Organization for Id Token verification.
        /// </summary>
        /// <remarks>
        /// - If you provide an Organization ID (a string with the prefix `org_`), it will be validated against the `org_id` claim of your user's ID Token. The validation is case-sensitive.
        /// - If you provide an Organization Name (a string *without* the prefix `org_`), it will be validated against the `org_name` claim of your user's ID Token.The validation is case-insensitive.
        /// </remarks>
        public string Organization { get; set; }
    }
}
