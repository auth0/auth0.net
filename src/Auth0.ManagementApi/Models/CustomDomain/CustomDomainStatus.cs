using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// The custom domain configuration status.
    /// </summary>
    public enum CustomDomainStatus
    {
        /// <summary>
        /// Domain is disabled.
        /// </summary>
        [EnumMember(Value = "disabled")] Disabled,

        /// <summary>
        /// Domain is pending.
        /// </summary>
        [EnumMember(Value = "pending")] Pending,

        /// <summary>
        /// Domain is pending verification.
        /// </summary>
        [EnumMember(Value = "pending_verification")]
        PendingVerification,

        /// <summary>
        /// Domain is ready
        /// </summary>
        [EnumMember(Value = "ready")] Ready
    }
}