using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    public enum LogoutInitiatorModes
    {
        /// <summary>
        /// All initiators are enabled.
        /// </summary>
        [EnumMember(Value = "all")]
        All,

        /// <summary>
        /// Specific initiators are enabled.
        /// </summary>
        [EnumMember(Value = "custom")]
        Custom
    }
}
