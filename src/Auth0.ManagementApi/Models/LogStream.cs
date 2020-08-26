using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Information about a log stream
    /// </summary>
    public class LogStream
    {
        /// <summary>
        /// The identifier of the log stream
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the log stream
        /// </summary>
        [JsonProperty("name")] 
        public string Name { get; set; }

        /// <summary>
        /// The status of the log stream
        /// </summary>
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LogStreamStatus Status { get; set; }

        /// <summary>
        /// The type of the log stream
        /// </summary>
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LogStreamType Type { get; set; }

        /// <summary>
        /// Information about the log stream sink
        /// </summary>
        [JsonProperty("sink")]
        public dynamic Sink { get; set; }
    }
}
