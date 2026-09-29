using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation.FeatureFlags;

[Serializable]
public record CreateVariationRequestContent
{
    /// <summary>
    /// A human-readable name for the variation
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A description of what this variation controls
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// Configuration overrides for this variation; keys must exist in the parent flag parameters. Empty {} is the baseline (control) variation that overrides nothing.
    /// </summary>
    [JsonPropertyName("overrides")]
    public Dictionary<string, object?> Overrides { get; set; } = new Dictionary<string, object?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
