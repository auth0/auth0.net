using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Content Security Policy configuration with multi-policy support.
/// </summary>
[Serializable]
public record ContentSecurityPolicyConfig : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether CSP is enabled.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [Optional]
    [JsonPropertyName("policies")]
    public IEnumerable<CspPolicy>? Policies { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("reporting_infrastructure")]
    public Optional<CspReportingInfrastructure?> ReportingInfrastructure { get; set; }

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
