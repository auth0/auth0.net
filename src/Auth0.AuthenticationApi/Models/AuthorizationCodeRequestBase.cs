namespace Auth0.AuthenticationApi.Models
{
    public abstract class AuthorizationCodeRequestBase
    {
        /// <summary>
        /// Authorization code to be exchanged.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Client ID of the application.
        /// </summary>
        public string ClientId { get; set; }


        /// <summary>
        /// Rredirect URI passed during the login process.
        /// </summary>
        public string RedirectUri { get; set; }
    }
}
