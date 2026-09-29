using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record AllocationItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("variation_id")]
    public string? VariationId { get; set; }

    [Optional]
    [JsonPropertyName("variation_name")]
    public string? VariationName { get; set; }

    [Optional]
    [JsonPropertyName("segment_id")]
    public string? SegmentId { get; set; }

    [Optional]
    [JsonPropertyName("segment_name")]
    public string? SegmentName { get; set; }

    [Optional]
    [JsonPropertyName("weight")]
    public int? Weight { get; set; }

    [Optional]
    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [Optional]
    [JsonPropertyName("is_control")]
    public bool? IsControl { get; set; }

    [Optional]
    [JsonPropertyName("is_fallback")]
    public bool? IsFallback { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("variation_snapshot")]
    public Optional<Dictionary<string, object?>?> VariationSnapshot { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("segment_snapshot")]
    public Optional<Dictionary<string, object?>?> SegmentSnapshot { get; set; }

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
