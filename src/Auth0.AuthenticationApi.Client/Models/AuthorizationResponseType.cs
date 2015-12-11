using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Client.Models
{
    /// <summary>
    /// Represents an authentication reponse type.
    /// </summary>
    public enum AuthorizationResponseType
    {
        /// <summary>
        /// The response type is a code
        /// </summary>
        Code,

        /// <summary>
        /// The response type is a token.
        /// </summary>
        Token
    }
}