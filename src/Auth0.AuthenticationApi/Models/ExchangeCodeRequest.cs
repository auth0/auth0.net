namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to exchange an authorization code for an access token during the OAuth authentication flow.
    /// </summary>
    public class ExchangeCodeRequest
    {
        /// <summary>
        /// The authorization code which will be exchanged
        /// </summary>
        public object AuthorizationCode { get; set; }

        /// <summary>
        /// The client ID of the Application
        /// </summary>
        public object ClientId { get; set; }

        /// <summary>
        /// The client secret of the application.
        /// </summary>
        public object ClientSecret { get; set; }

        /// <summary>
        /// The redirect URI which was passed during the login process
        /// </summary>
        public object RedirectUri { get; set; }
    }
}