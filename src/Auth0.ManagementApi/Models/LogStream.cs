using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Information about a log stream
    /// </summary>
    public class LogStream : LogStreamBase
    {
        /// <summary>
        /// The identifier of the log stream
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The status of the log stream
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LogStreamStatus Status { get; set; }
    }
}
