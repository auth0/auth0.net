using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Experimentation;

[Serializable]
public record CreateSegmentRequestContent
{
    /// <summary>
    /// A human-readable name for the segment
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// A description of the segment
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// An ordered list of rules. A segment matches if any rule matches. Each rule is limited to 4KB and the whole segment to 10KB (serialized).
    /// </summary>
    [JsonPropertyName("rules")]
    public IEnumerable<SegmentRule> Rules { get; set; } = new List<SegmentRule>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
