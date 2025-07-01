using System.Collections.Generic;
using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.NetworkAcl;

/// <summary>
/// Represents a rule in a Network Access Control List (ACL).
/// </summary>
public class NetworkAclRule
{
    /// <inheritdoc cref="NetworkAclAction"/>
    [JsonProperty("action")]
    public NetworkAclAction Action { get; set; } = new();
    
    /// <inheritdoc cref="NetworkAclMatch"/>
    [JsonProperty("match")]
    public NetworkAclMatch? Match { get; set; }
    
    /// <inheritdoc cref="NetworkAclMatch"/>
    [JsonProperty("not_match")]
    public NetworkAclMatch? NotMatch { get; set; }
    
    /// <inheritdoc cref="NetworkAclScope"/>
    [JsonProperty("scope")]
    [JsonConverter(typeof(StringEnumConverter))]
    public NetworkAclScope Scope { get; set; }
}

/// <summary>
/// The action to be taken when a request matches or does not match the criteria defined in the Network ACL rule.
/// </summary>
public class NetworkAclAction
{
    /// <summary>
    /// Indicates the rule will block requests that either match or not_match specific criteria
    /// </summary>
    [JsonProperty("block")]
    public bool? Block { get; set; }
    
    /// <summary>
    /// Indicates the rule will allow requests that either match or not_match specific criteria.
    /// </summary>
    [JsonProperty("allow")]
    public bool? Allow { get; set; }
    
    /// <summary>
    /// Indicates the rule will log requests that either match or not_match specific criteria
    /// </summary>
    [JsonProperty("log")]
    public bool? Log { get; set; }
    
    /// <summary>
    /// Indicates the rule will redirect requests that either match or not_match specific criteria
    /// </summary>
    [JsonProperty("redirect")]
    public bool? Redirect { get; set; }
    
    /// <summary>
    /// The URI to which the match or not_match requests will be routed
    /// </summary>
    [JsonProperty("redirect_uri")]
    public string? RedirectUri { get; set; }
}

/// <summary>
/// The different criteria that can be used to match requests in a Network ACL rule.
/// </summary>
public class NetworkAclMatch
{
    [JsonProperty("asns")]
    public IList<int>? Asns { get; set; }
    
    [JsonProperty("geo_country_codes")]
    public IList<string>? GeoCountryCodes { get; set; }
    
    [JsonProperty("geo_subdivision_codes")]
    public IList<string>? GeoSubdivisionCodes { get; set; }
    
    [JsonProperty("ipv4_cidrs")]
    public IList<string>? Idv4Cidrs { get; set; }
    
    [JsonProperty("ipv6_cidrs")]
    public IList<string>? Idv6Cidrs { get; set; }
    
    [JsonProperty("ja3_fingerprints")]
    public IList<string>? Ja3Fingerprints { get; set; }
    
    [JsonProperty("ja4_fingerprints")]
    public IList<string>? Ja4Fingerprints { get; set; }
    
    [JsonProperty("user_agents")]
    public IList<string>? UserAgents { get; set; }
}

/// <summary>
/// Identifies the origin of the request 
/// </summary>
public enum NetworkAclScope
{
    /// <summary>
    /// Identifies the origin of the request as the Management API 
    /// </summary>
    [EnumMember(Value = "management")]
    Management,

    /// <summary>
    /// Identifies the origin of the request as the Authentication API 
    /// </summary>
    [EnumMember(Value = "authentication")]
    Authentication,
    
    /// <summary>
    /// Identifies the origin of the request as the Tenant. 
    /// </summary>
    [EnumMember(Value = "tenant")]
    Tenant
}
