using Auth0.Core;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Specified the properies for creating a new request.
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