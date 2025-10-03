using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Indicates whether device binding security should be enforced for the app.
/// If set to 'ip', the app will enforce device binding by IP, meaning that consumption of session_token must be
/// done from the same IP of the issuer. Likewise, if set to 'asn', device binding is enforced by ASN, meaning
/// consumption of session_token must be done from the same ASN as the issuer.
/// If set to 'null', device binding is not enforced.
/// </summary>
public enum DeviceBindingType
{
    /// <summary>
    /// Ip
    /// </summary>
    [EnumMember(Value = "ip")]
    Ip,
    
    /// <summary>
    /// Asn
    /// </summary>
    [EnumMember(Value = "asn")]
    Asn,
    
    /// <summary>
    /// None
    /// </summary>
    [EnumMember(Value = "none")]
    None,
    
}