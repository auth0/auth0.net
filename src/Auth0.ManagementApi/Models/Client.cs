using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents a client (App) in Auth0
    /// </summary>
    public class Client : ClientBase
    {
        /// <summary>
        /// The id of the client.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Client signing keys.
        /// </summary>
        [JsonProperty("signing_keys")]
        public SigningKey[] SigningKeys { get; set; }

        /// <summary>
        /// The type of application this client represents
        /// </summary>
        [JsonProperty("app_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientApplicationType ApplicationType { get; set; }

        /// <summary>
        /// Defines the requested authentication method for the token endpoint.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [JsonProperty("token_endpoint_auth_method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenEndpointAuthMethod TokenEndpointAuthMethod { get; set; }
    }
}