using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.NetworkAcl;

public class NetworkAclCreateRequest
{
    [JsonProperty("description")]
    public string Description { get; set; }
    
    /// <summary>
    /// Indicates whether this access control list is actively being used.
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
}