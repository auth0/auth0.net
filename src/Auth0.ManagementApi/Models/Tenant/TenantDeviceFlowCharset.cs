using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// The character set for generating a User Code.
    /// </summary>
    public enum TenantDeviceFlowCharset
    {
        [EnumMember(Value = "base20")]
        Base20,

        [EnumMember(Value = "digits")]
        Digits
    }
}
