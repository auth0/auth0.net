namespace Auth0.AuthenticationApi.Client.Models
{
    /// <summary>
    /// Contains the response from an authentication request.
    /// </summary>
    public class AuthenticationResponse
    {
        /// <summary>
        /// Gets or sets the identifier token.
        /// </summary>
        public string IdToken { get; set; }

        /// <summary>
        /// Gets or sets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        public string TokenType { get; set; }
    }
}