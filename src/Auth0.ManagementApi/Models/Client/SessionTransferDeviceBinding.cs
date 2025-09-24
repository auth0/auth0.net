using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Device binding enforcement options for session transfer.
/// </summary>
public enum SessionTransferDeviceBinding
{
    [EnumMember(Value = "asn")]
    Asn,
    [EnumMember(Value = "ip")]
    Ip,
    [EnumMember(Value = "none")]
    None
}