using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Allowed authentication methods for session transfer.
/// </summary>
public enum SessionTransferAuthenticationMethod
{
    [EnumMember(Value = "cookie")]
    Cookie,
    [EnumMember(Value = "query")]
    Query
}
