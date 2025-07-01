using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Defines the default Organization ID and flows
/// </summary>
public class DefaultOrganization
{
    /// <summary>
    /// The default Organization ID to be used
    /// </summary>
    [JsonProperty("organization_id")]
    public string OrganizationId { get; set; }
        
    /// <summary>
    /// The default Organization usage
    /// </summary>
    [JsonProperty("flows", ItemConverterType = typeof(StringEnumConverter))]
    public Flows[] Flows { get; set; }
        
}