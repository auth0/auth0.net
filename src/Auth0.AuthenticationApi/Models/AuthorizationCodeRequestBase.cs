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
        /// What <see cref="JwtSignatureAlgorithm"/> is used to verify the signature
        /// of Id Tokens.
        /// </summary>
        public JwtSignatureAlgorithm SigningAlgorithm {  get; set; }

        /// <summary>
        /// Rredirect URI passed during the login process.
        /// </summary>
        public string RedirectUri { get; set; }

        /// <summary>
        /// Optional client secret of the application for Id Token verification.
        /// </summary>
        public virtual string ClientSecret { get; set; }
    }
}
