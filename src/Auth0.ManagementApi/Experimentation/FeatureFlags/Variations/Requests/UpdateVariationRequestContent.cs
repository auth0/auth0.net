using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation.FeatureFlags;

[Serializable]
public record UpdateVariationRequestContent
{
    /// <summary>
    /// A human-readable name for the variation
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A description of what this variation controls
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    [Optional]
    [JsonPropertyName("overrides")]
    public Dictionary<string, object?>? Overrides { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
