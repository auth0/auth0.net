using Newtonsoft.Json;

namespace Auth0.AuthenticationApi.Models
{
    /// <summary>
    /// Represents an identifier token delegation request.
    /// </summary>
    public class IdTokenDelegationRequest : DelegationRequestBase
    {
        /// <summary>
        /// Gets or sets the identifier token.
        /// </summary>
        [JsonProperty("id_token")]
        public string IdToken { get; set; }

        /// <summary>
        /// Gets or sets the type of the API.
        /// </summary>
        [JsonProperty("api_type")]
        public string ApiType { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdTokenDelegationRequest"/> class.
        /// </summary>
        /// <param name="sourceClientId">The source client identifier.</param>
        /// <param name="targetClientId">The target client identifier.</param>
        /// <param name="idToken">The identifier token.</param>
        public IdTokenDelegationRequest(string sourceClientId, string targetClientId, string idToken) : base(sourceClientId, targetClientId)
        {
            IdToken = idToken;
        }


    }
}
