using Auth0.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// 
    /// </summary>
    public class ClientUpdateRequest : ClientBase
    {
        /// <summary>
        /// The type of application this client represents
        /// </summary>
        [JsonProperty("app_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ClientApplicationType? ApplicationType { get; set; } = null;

        /// <summary>
        /// Defines the requested authentication method for the token endpoint.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        [JsonProperty("token_endpoint_auth_method")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TokenEndpointAuthMethod? TokenEndpointAuthMethod { get; set; } = null;
    }

}