namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request get a token using the Client Credentials Grant flow
    /// </summary>
    public class ClientCredentialsTokenRequest
    {
        /// <summary>
        /// The unique identifier of the target API you want to access.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Your application's Client ID
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Your application's Client Secret.
        /// </summary>
        public string ClientSecret { get; set; }
    }
}