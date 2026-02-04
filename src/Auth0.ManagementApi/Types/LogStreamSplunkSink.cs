using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record LogStreamSplunkSink : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Splunk URL Endpoint
    /// </summary>
    [JsonPropertyName("splunkDomain")]
    public required string SplunkDomain { get; set; }

    /// <summary>
    /// Port
    /// </summary>
    [JsonPropertyName("splunkPort")]
    public required string SplunkPort { get; set; }

    /// <summary>
    /// Splunk token
    /// </summary>
    [JsonPropertyName("splunkToken")]
    public required string SplunkToken { get; set; }

    /// <summary>
    /// Verify TLS certificate
    /// </summary>
    [JsonPropertyName("splunkSecure")]
    public required bool SplunkSecure { get; set; }

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
