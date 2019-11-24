namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request get a token using the Client Credentials Grant flow.
    /// </summary>
    public class ClientCredentialsTokenRequest
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
    }
}