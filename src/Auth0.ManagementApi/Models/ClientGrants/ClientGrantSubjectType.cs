using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// The type of application access the client grant allows.
/// </summary>
public enum ClientGrantSubjectType
{
    [EnumMember(Value = "client")]
    Client,
    
    [EnumMember(Value = "user")]
    User,
}