using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record AllocationRequestItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The ID of the variation to allocate
    /// </summary>
    [JsonPropertyName("variation_id")]
    public required string VariationId { get; set; }

    /// <summary>
    /// Percentage weight for this allocation (percentage strategy only)
    /// </summary>
    [Optional]
    [JsonPropertyName("weight")]
    public int? Weight { get; set; }

    /// <summary>
    /// The segment this allocation targets (segment strategy only)
    /// </summary>
    [Optional]
    [JsonPropertyName("segment_id")]
    public string? SegmentId { get; set; }

    /// <summary>
    /// Evaluation order; 1 = highest priority (segment strategy only)
    /// </summary>
    [Optional]
    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    /// <summary>
    /// Whether this allocation is the control group
    /// </summary>
    [JsonPropertyName("is_control")]
    public required bool IsControl { get; set; }

    /// <summary>
    /// Whether this allocation is the default fallback (segment strategy only)
    /// </summary>
    [Optional]
    [JsonPropertyName("is_fallback")]
    public bool? IsFallback { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
