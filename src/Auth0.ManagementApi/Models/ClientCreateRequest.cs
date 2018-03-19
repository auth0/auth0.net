using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{

    /// <summary>
    /// Requests structure for creating a new client.
    /// </summary>
    public class ClientCreateRequest : ClientBase
    {
        /// <summary>
        /// True if the client is a heroku application, false otherwise
        /// </summary>
        [JsonProperty("is_heroku_app")]
        public bool? IsHerokuApp { get; set; }

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