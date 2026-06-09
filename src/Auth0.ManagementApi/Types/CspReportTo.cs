using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Report-To header configuration.
/// </summary>
[Serializable]
public record CspReportTo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Reporting group identifier.
    /// </summary>
    [Optional]
    [JsonPropertyName("group")]
    public string? Group { get; set; }

    /// <summary>
    /// Maximum age in seconds for the Report-To header.
    /// </summary>
    [Optional]
    [JsonPropertyName("max_age")]
    public int? MaxAge { get; set; }

    [Optional]
    [JsonPropertyName("endpoints")]
    public IEnumerable<CspReportToEndpoint>? Endpoints { get; set; }

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
