using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// The default Organization usage
/// </summary>
public enum Flows
{
    /// <summary>
    /// Client-Credentials flow
    /// </summary>
    [EnumMember(Value = "client_credentials")]
    ClientCredentials
}