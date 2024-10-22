using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Sessions
{
    /// <summary>
    /// Client details for the session
    /// </summary>
    public class ClientDetails
    {
        /// <summary>
        /// ID of client for the session
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    }
}