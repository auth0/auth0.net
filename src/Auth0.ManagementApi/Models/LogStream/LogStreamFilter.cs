using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Only logs events matching these filters will be delivered by the stream.
    /// If omitted or empty, all events will be delivered.
    /// </summary>
    public class LogStreamFilter
    {
        /// <summary>
        /// Filter type.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public LogStreamFilterType Type { get; set; }

        /// <summary>
        /// Category group name
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("name")]
        public LogStreamFilterName Name { get; set; }
    }
}