using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// A single CSP policy with mode, directives, flags, and optional reporting.
/// </summary>
[Serializable]
public record CspPolicy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("mode")]
    public CspPolicyMode? Mode { get; set; }

    [Optional]
    [JsonPropertyName("directives")]
    public Dictionary<string, IEnumerable<string>>? Directives { get; set; }

    [Optional]
    [JsonPropertyName("flags")]
    public IEnumerable<CspFlag>? Flags { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("reporting")]
    public Optional<CspPolicyReporting?> Reporting { get; set; }

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
