using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{ 
    /// <summary>
    /// The type of expiration for a <see cref="RefreshToken"/>
    /// </summary>
    public enum RefreshTokenExpirationType
    {
        /// <summary>
        /// Expiring
        /// </summary>
        [EnumMember(Value = "expiring")]
        Expiring,

        /// <summary>
        /// Non-Expiring
        /// </summary>
        [EnumMember(Value = "non-expiring")]
        NonExpiring,
    }
}
