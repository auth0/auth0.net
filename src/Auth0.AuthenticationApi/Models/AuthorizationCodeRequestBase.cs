namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Base class for all types of Authorization Code requests.
    /// </summary>
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
        /// What <see cref="JwtSignatureAlgorithm"/> is used to verify the signature
        /// of Id Tokens.
        /// </summary>
        public JwtSignatureAlgorithm SigningAlgorithm {  get; set; }

        /// <summary>
        /// Redirect URI passed during the login process.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Client secret of the application for Id Token verification.
        /// </summary>
        /// <remarks>
        /// Optional except when using <see cref="AuthorizationCodeRequestBase"/>.
        /// </remarks>
        public string ClientSecret { get; set; }

        /// <summary>
        /// Organization for Id Token verification.
        /// </summary>
        /// <remarks>
        /// Optional except when using <see cref="AuthorizationCodeRequestBase"/>.
        /// </remarks>
        public string Organization { get; set; }
    }
}
