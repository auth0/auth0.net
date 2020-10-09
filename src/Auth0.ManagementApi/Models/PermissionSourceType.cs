using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Types of permission sources
    /// </summary>
    public enum PermissionSourceType
    {
        /// <summary>
        /// Permission assigned directly to user
        /// </summary>
        [EnumMember(Value = "direct")]
        Direct,

        /// <summary>
        /// Permission assigned via role
        /// </summary>
        [EnumMember(Value = "role")]
        Role
    }
}
