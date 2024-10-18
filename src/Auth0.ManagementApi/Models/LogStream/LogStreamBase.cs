using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    public class LogStreamBase
    {
        /// <summary>
        /// The name of the log stream
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

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
