using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Defines application access permission for a resource server.
/// </summary>
public class SubjectTypeAuthorization
{
    /// <summary>
    /// <inheritdoc cref="SubjectTypeAuthorizationUser" />
    /// </summary>
    [JsonProperty("user")]
    public SubjectTypeAuthorizationUser? User { get; set; }
    
    /// <summary>
    /// <inheritdoc cref="SubjectTypeAuthorizationClient" />
    /// </summary>
    [JsonProperty("client")]
    public SubjectTypeAuthorizationClient? Client { get; set; }
}

/// <summary>
/// Access Permissions for user flows
/// </summary>
public class SubjectTypeAuthorizationUser
{
    [JsonProperty("policy")]
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public SubjectTypeAuthorizationUserPolicy? Policy { get; set; }
}

/// <summary>
/// Access Permissions for client flows
/// </summary>
public class SubjectTypeAuthorizationClient
{
    /// <summary>
    /// <inheritdoc cref="SubjectTypeAuthorizationClientPolicy"/>
    /// </summary>
    [JsonProperty("policy")]
    [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
    public SubjectTypeAuthorizationClientPolicy? Policy { get; set; }
}

/// <summary>
/// Defines the user flows policy for the resource server
/// </summary>
public enum SubjectTypeAuthorizationUserPolicy
{
    [EnumMember(Value = "allow_all")]
    AllowAll,
    
    [EnumMember(Value = "require_client_grant")]
    RequireClientGrant,
    
    [EnumMember(Value = "deny_all")]
    DenyAll,
}

/// <summary>
/// Defines the client flows policy for the resource server.
/// </summary>
public enum SubjectTypeAuthorizationClientPolicy
{
    [EnumMember(Value = "require_client_grant")]
    RequireClientGrant,
    
    [EnumMember(Value = "deny_all")]
    DenyAll,
}

