using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles;

/// <summary>
/// Configuration for the setup of the connection’s domain_aliases in the self-service SSO flow.
/// </summary>
public class DomainAliasesConfig
{
    /// <inheritdoc cref="Auth0.ManagementApi.Models.SelfServiceProfiles.DomainVerification"/>>
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("domain_verification")]
    public DomainVerification DomainVerification { get; set; }
}

/// <summary>
/// Whether the end user should complete the domain verification step.
/// Possible values are <see cref="None"/> (the step is not shown to the user),
/// <see cref="Optional"/> (the user may add a domain alias in the domain verification step)
/// or
/// <see cref="Required"/> (the user must add a domain alias in order to enable the connection).
/// Defaults to <see cref="None"/>.
/// </summary>
public enum DomainVerification
{
    [EnumMember(Value = "none")]
    None,
    
    [EnumMember(Value = "optional")]
    Optional,
    
    [EnumMember(Value = "required")]
    Required
}