namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to exchange an authorization code for an access token during the OAuth authentication flow.
    /// </summary>
    public class AuthorizationCodeTokenRequest
    {
        /// <summary>
        /// The authorization code which will be exchanged
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The client ID of the Application
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// The client secret of the application.
        /// </summary>
        public string ClientSecret { get; set; }

        /// <summary>
        /// The redirect URI which was passed during the login process
        /// </summary>
        public string RedirectUri { get; set; }
    }
}