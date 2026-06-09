using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// X-XSS-Protection header configuration (deprecated header, use CSP instead).
/// </summary>
[Serializable]
public record XssProtectionConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether X-XSS-Protection header is enabled.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [Optional]
    [JsonPropertyName("mode")]
    public XssProtectionMode? Mode { get; set; }

    /// <summary>
    /// HTTPS endpoint for X-XSS-Protection violation reports.
    /// </summary>
    [Optional]
    [JsonPropertyName("report_uri")]
    public string? ReportUri { get; set; }

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
