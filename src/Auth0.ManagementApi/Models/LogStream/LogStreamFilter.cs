using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    public class LogStreamFilter
    {
        /// <summary>
        /// Type of filter
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Name of the filter
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
