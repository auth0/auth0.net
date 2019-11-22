namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents an authentication reponse type.
    /// </summary>
    public enum AuthorizationResponseType
    {
        /// <summary>
        /// Response is an authorization code.
        /// </summary>
        Code,

        /// <summary>
        /// Response is an access_token.
        /// </summary>
        Token,

        /// <summary>
        /// Response is an id_token.
        /// </summary>
        IdToken
    }
}