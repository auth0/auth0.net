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
        /// Run status of this job.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// Type of job this is.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Unique identifier of this job that can be used to retrieve status later.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Connection name to which users will be inserted.
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// Connection identifier of the connection to which users will be inserted.
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// Date and time the job was created.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Summary of how entries were processed by this job.
        /// </summary>
        [JsonProperty("summary")]
        public JobSummary Summary { get; set; }

        /// <summary>
        /// File format for this job.
        /// </summary>
        [JsonProperty("format")]
        public string Format { get; set; }

        /// <summary>
        /// Uri location of downloadable results for this job.
        /// </summary>
        /// <remarks>
        /// Used by user export jobs.
        /// </remarks>
        [JsonProperty("location")]
        public Uri Location { get; set; }

        /// <summary>
        /// How much of this job has been completed as a percentage.
        /// </summary>
        [JsonProperty("percentage_done")]
        public int PercentageDone { get; set; }

        /// <summary>
        /// Amount of expected time left to complete this job in seconds.
        /// </summary>
        [JsonProperty("time_left_seconds")]
        public int TimeLeftSeconds { get; set; }

        /// <summary>
        /// Amount of expected time left to complete this job.
        /// </summary>
        [JsonIgnore]
        public TimeSpan TimeLeft
        {
            get { return TimeSpan.FromSeconds(TimeLeftSeconds); }
            set { TimeLeftSeconds = (int)value.TotalSeconds; }
        }

        /// <summary>
        /// Customer-defined id.
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }
    }
}
