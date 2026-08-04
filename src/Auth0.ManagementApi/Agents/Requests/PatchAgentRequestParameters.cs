using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record PatchAgentRequestParameters
{
    /// <summary>
    /// The agent name. Cannot contain &lt;, &gt;, or null bytes.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Arbitrary key-value metadata for the agent. Pass null to clear all metadata.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("metadata")]
    public Optional<Dictionary<string, object?>?> Metadata { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
