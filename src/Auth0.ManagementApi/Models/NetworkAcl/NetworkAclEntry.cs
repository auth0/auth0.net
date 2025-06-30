using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.NetworkAcl;

public record NetworkAclEntry
{
    [JsonProperty("id")]
    public string Id { get; }
    
    [JsonProperty("description")]
    public string Description { get; set; }
    
    /// <summary>
    /// Indicates whether or not this access control list is actively being used.
    /// </summary>
    [JsonProperty("active")]
    public bool? Active { get; set; }
    
    /// <summary>
    /// Indicates the order in which the ACL will be evaluated relative to other ACL rules.
    /// </summary>
    [JsonProperty("priority")]
    public int? Priority { get; set; }
    
    /// <inheritdoc cref="NetworkAclRule"/>
    [JsonProperty("rule")]
    public NetworkAclRule NetworkAclRule { get; set; }
    
    /// <summary>
    /// The timestamp when the Network ACL Configuration was created
    /// </summary>
    [JsonProperty("created_at")]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// The timestamp when the Network ACL Configuration was last updated
    /// </summary>
    [JsonProperty("updated_at")]
    public DateTime UpdatedAt { get; set; }
}