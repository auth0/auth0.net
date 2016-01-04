using Newtonsoft.Json;

namespace Auth0.Core
{
    /// <summary>
    /// Represents a background job.
    /// </summary>
    public class Job
    {
        /// <summary>
        /// The job's status.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// The type of job.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The job's identifier. Useful to retrieve its status later on.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// The connection identifier of the connection to which users will be inserted.
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

    }
}