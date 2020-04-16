using Newtonsoft.Json;
using System;

namespace Auth0.ManagementApi.Models
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
        /// The connection to which users will be inserted.
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// The connection identifier of the connection to which users will be inserted.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// The date and time the job was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Summary of how entries were processed by this job.
        /// </summary>
        [JsonProperty("summary")]
        public JobSummary Summary { get; set; }
    }
}