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
        /// Gets or sets an optional scope for the access request.
        /// </summary>
        /// <remarks>
        /// The requested scope must not include any scope not originally granted
        /// by the resource owner, and if omitted is treated as equal to the scope originally
        /// granted by the resource owner.
        /// </remarks>
        public string Scope { get; set; }

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