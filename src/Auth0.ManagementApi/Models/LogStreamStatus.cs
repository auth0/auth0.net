using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// The possible statuses of the log stream
    /// </summary>
    public enum LogStreamStatus
    {
        /// <summary>
        /// The log stream is active
        /// </summary>
        [EnumMember(Value = "active")]
        Active,

        /// <summary>
        /// The log stream is paused
        /// </summary>
        [EnumMember(Value = "paused")]
        Paused,

        /// <summary>
        /// The log stream is suspended
        /// </summary>
        [EnumMember(Value = "suspended")]
        Suspended
    }
}
