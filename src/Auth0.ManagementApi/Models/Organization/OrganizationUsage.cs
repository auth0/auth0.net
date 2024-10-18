using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// Organization usage for a client
    /// </summary>
    public enum OrganizationUsage
    {
        /// <summary>
        /// Client denies organization usage
        /// </summary>
        [EnumMember(Value = "deny")]
        Deny,

        /// <summary>
        /// Client allows organization usage
        /// </summary>
        [EnumMember(Value = "allow")]
        Allow,

        /// <summary>
        /// Client requires organization usage
        /// </summary>
        [EnumMember(Value = "require")]
        Require
    }
}