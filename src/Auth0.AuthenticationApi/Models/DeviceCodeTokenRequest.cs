namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to exchange a Device Code for an access token during the OAuth authentication flow.
    /// </summary>
    public class DeviceCodeTokenRequest
    {
        /// <summary>
        /// Device code to be exchanged.
        /// </summary>
        public string DeviceCode { get; set; }

        /// <summary>
        /// Client ID of the application.
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// What <see cref="JwtSignatureAlgorithm"/> is used to verify the signature
        /// of Id Tokens.
        /// </summary>
        public JwtSignatureAlgorithm SigningAlgorithm { get; set; }
    }
}