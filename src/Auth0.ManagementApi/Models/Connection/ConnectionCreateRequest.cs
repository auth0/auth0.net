using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specifies the properies for creating a new connection.
    /// </summary>
    /// <remarks>
    /// At least the <see cref="ConnectionBase.Name"/> and <see cref="Strategy"/> properties are required.
    /// </remarks>
    public class ConnectionCreateRequest : ConnectionBase
    {
        /// <summary>
        /// The identity provider identifier for the connection.
        /// </summary>
        [JsonProperty("strategy")]
        public string Strategy { get; set; }
    }
}