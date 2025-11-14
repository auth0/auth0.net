using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Intended mechanism for Proof-of-Possession
/// </summary>
public enum Mechanism
{
    /// <summary>
    /// Mechanism 'mtls'
    /// </summary>
    [EnumMember(Value = "mtls")]
    Mtls,
    
    /// <summary>
    /// Mechanism 'dpop'
    /// </summary>
    [EnumMember(Value = "dpop")]
    DPoP,
}