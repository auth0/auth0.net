using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models.Connections
{
    /// <summary>
    /// Verification methods for email authentication
    /// </summary>
    public enum ConnectionOptionsEmailVerificationMethod
    {
        /// <summary>
        /// Use magic link for verification
        /// </summary>
        [EnumMember(Value = "link")]
        Link,

        /// <summary>
        /// Use one-time password for verification
        /// </summary>
        [EnumMember(Value = "otp")]
        Otp
    }
}