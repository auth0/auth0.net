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
        /// The name of the connection
        /// </summary>
        [JsonProperty("connection")]
        public string Connection { get; set; }

        /// <summary>
        /// The id of the connection
        /// </summary>
        [JsonProperty("connection_id")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// The date when the event was created
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// A description for the event
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Additional (and very useful) details about the event.
        /// </summary>
        [JsonProperty("details")]
        public dynamic Details { get; set; }

        /// <summary>
        /// The hostname for the request.
        /// </summary>
        [JsonProperty("hostname")]
        public string HostName { get; set; }

        /// <summary>
        /// The unique identifier for the log entry
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        /// <summary>
        /// The User ID of the user for an impersonation request.
        /// </summary>
        [JsonProperty("impersonator_user_id")]
        public string ImpersonatorUserId { get; set; }

        /// <summary>
        /// The Username of the user for an impersonation request.
        /// </summary>
        [JsonProperty("impersonator_user_name")]
        public string ImpersonatorUserName { get; set; }

        /// <summary>
        /// The IP address of the log event source
        /// </summary>
        [JsonProperty("ip")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Whether the event was from a mobile device.
        /// </summary>
        [JsonProperty("isMobile")]
        public bool? IsMobile { get; set; }

        /// <summary>
        /// Additional details about the event's ip trace location. If the ip matches either as private or localhost it returns
        /// an empty object
        /// </summary>
        [JsonProperty("location_info")]
        public dynamic LocationInfo { get; set; }

        /// <summary>
        /// The strategy used
        /// </summary>
        [JsonProperty("strategy")]
        public string Strategy { get; set; }

        /// <summary>
        /// The strategy type
        /// </summary>
        [JsonProperty("strategy_type")]
        public string StrategyType { get; set; }

        /// <summary>
        /// The log event type
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The user's browser user-agent
        /// </summary>
        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }

        /// <summary>
        /// The user's unique identifier
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// The user's name
        /// </summary>
        [JsonProperty("user_name")]
        public string UserName { get; set; }
    }
}