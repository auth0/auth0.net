using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Information about a log entry
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        /// The unique identifier for the log entry
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// The date when the event was created
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// The log event type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The identifier of the client
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// The name of the client
        /// </summary>
        [JsonProperty("client_name")]
        public string ClientName { get; set; }

        /// <summary>
        /// The IP address of the log event source
        /// </summary>
        [JsonProperty("ip")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Additional details about the event's ip trace location. If the ip matches either as private or localhost it returns an empty object
        /// </summary>
        [JsonProperty("location_info")]
        public dynamic LocationInfo { get; set; }

        /// <summary>
        /// Additional (and very useful) details about the event.
        /// </summary>
        [JsonProperty("details")]
        public dynamic Details { get; set; }

        /// <summary>
        /// The user's unique identifier
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}