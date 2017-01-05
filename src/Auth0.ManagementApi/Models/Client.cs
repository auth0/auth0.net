using Newtonsoft.Json;

namespace Auth0.Core
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
    }
}