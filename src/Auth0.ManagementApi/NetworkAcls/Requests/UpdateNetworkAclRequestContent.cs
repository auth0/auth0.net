using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateNetworkAclRequestContent
{
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Indicates whether or not this access control list is actively being used
    /// </summary>
    [Optional]
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// Indicates the order in which the ACL will be evaluated relative to other ACL rules.
    /// </summary>
    [Optional]
    [JsonPropertyName("priority")]
    public double? Priority { get; set; }

    [Optional]
    [JsonPropertyName("rule")]
    public NetworkAclRule? Rule { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
