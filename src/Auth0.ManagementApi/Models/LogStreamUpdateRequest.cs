using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Information required to update a log stream
    /// </summary>
    public class LogStreamUpdateRequest
    { 
        /// <summary>
        /// The name of the log stream
        /// </summary>
        [JsonProperty("name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// The new status of the log stream
        /// </summary>
        [JsonProperty("status", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public LogStreamUpdateStatus? Status { get; set; }

        /// <summary>
        /// The new collection of properties describing the log stream sink
        /// </summary>
        [JsonProperty("sink", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public dynamic Sink { get; set; }
    }
}
