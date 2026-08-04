using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateAgentRequestContent
{
    /// <summary>
    /// The agent name. Cannot contain &lt;, &gt;, or null bytes.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Optional client ID to associate with the agent
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// Optional external identifier for the agent. Immutable after creation. Must be unique within the tenant.
    /// </summary>
    [Optional]
    [JsonPropertyName("external_agent_id")]
    public string? ExternalAgentId { get; set; }

    [Optional]
    [JsonPropertyName("metadata")]
    public Dictionary<string, object?>? Metadata { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
