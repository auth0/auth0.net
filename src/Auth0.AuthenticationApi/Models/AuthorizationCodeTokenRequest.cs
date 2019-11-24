namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to exchange an authorization code for an access token during the OAuth authentication flow.
    /// </summary>
    public class AuthorizationCodeTokenRequest : AuthorizationCodeRequestBase
    {
        /// <summary>
        /// Client secret of the application.
        /// </summary>
        public string ClientSecret { get; set; }
    }
}