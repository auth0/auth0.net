using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation;

[Serializable]
public record CreateFeatureFlagRequestContent
{
    /// <summary>
    /// A human-readable name for the feature flag
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A description of what this feature flag controls
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("parameters")]
    public Dictionary<string, FeatureFlagConfigParam> Parameters { get; set; } =
        new Dictionary<string, FeatureFlagConfigParam>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
