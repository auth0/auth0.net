using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Represents the results summary of a job.
    /// </summary>
    public class JobSummary
    {
        /// <summary>
        /// Number of entries that failed.
        /// </summary>
        [JsonProperty("failed")]
        public int Failed { get; set; }

        /// <summary>
        /// Number of entries that were successfully updated.
        /// </summary>
        [JsonProperty("updated")]
        public int Updated { get; set; }

        /// <summary>
        /// Number of entries that were successfully inserted.
        /// </summary>
        [JsonProperty("inserted")]
        public int Inserted { get; set; }

        /// <summary>
        /// Number of total entries for this job.
        /// </summary>
        [JsonProperty("total")]
        public int Total { get; set; }
    }
}