using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Per-policy reporting configuration.
/// </summary>
[Serializable]
public record CspPolicyReporting : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// HTTPS endpoint for CSP violation reports.
    /// </summary>
    [Optional]
    [JsonPropertyName("report_uri")]
    public string? ReportUri { get; set; }

    /// <summary>
    /// Report-To group name for modern reporting.
    /// </summary>
    [Optional]
    [JsonPropertyName("report_to_group")]
    public string? ReportToGroup { get; set; }

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
