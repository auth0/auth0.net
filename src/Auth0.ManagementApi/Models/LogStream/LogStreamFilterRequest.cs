using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class LogStreamFilterRequest
    {
        /// <summary>
        /// Type of filter
        /// </summary>
        [JsonProperty("type")]
        public LogStreamFilterType Type { get; set; }

        /// <summary>
        /// Name of the filter
        /// </summary>
        [JsonProperty("name")]
        public LogStreamFilterName Name { get; set; }
    }
}
