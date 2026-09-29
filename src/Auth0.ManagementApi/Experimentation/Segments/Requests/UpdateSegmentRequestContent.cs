using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation;

[Serializable]
public record UpdateSegmentRequestContent
{
    /// <summary>
    /// A human-readable name for the segment
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A description of the segment
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    /// <summary>
    /// Replaces the entire rules array. Each rule is limited to 4KB and the whole segment to 10KB (serialized).
    /// </summary>
    [Optional]
    [JsonPropertyName("rules")]
    public IEnumerable<SegmentRule>? Rules { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
