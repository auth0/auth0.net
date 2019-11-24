namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents a request to exchange an authorization code (PKCE) for an access token during the OAuth authentication flow.
    /// </summary>
    public class AuthorizationCodePkceTokenRequest : AuthorizationCodeRequestBase
    {
        /// <summary>
        /// Cryptographically random key that was used to generate the `code_challenge` passed to the `/authorize` endpoint.
        /// </summary>
        public string CodeVerifier { get; set; }
    }
}