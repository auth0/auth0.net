namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents an authentication reponse type.
    /// </summary>
    public enum AuthorizationResponseType
    {
        /// <summary>
        /// The response type is an authorization code.
        /// </summary>
        Code,

        /// <summary>
        /// The response type is an access_token.
        /// </summary>
        Token,

        /// <summary>
        /// The response type is an id_token.
        /// </summary>
        IdToken
    }
}