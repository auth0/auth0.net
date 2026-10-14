using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation;

[Serializable]
public record UpdateFeatureFlagRequestContent
{
    /// <summary>
    /// A human-readable name for the feature flag
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A description of what this feature flag controls
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    [Optional]
    [JsonPropertyName("parameters")]
    public Dictionary<string, FeatureFlagConfigParam>? Parameters { get; set; }

    /// <summary>
    /// Target lifecycle status (draft → active, draft → archived, active → archived). Activating a flag requires at least 2 variations. When combined with field edits, the edits and the transition are applied together; if the transition is rejected, no edits are applied.
    /// </summary>
    [Optional]
    [JsonPropertyName("status")]
    public FeatureFlagStatusEnum? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
