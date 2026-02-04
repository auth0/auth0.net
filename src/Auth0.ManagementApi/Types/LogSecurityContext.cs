using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Information about security-related signals.
/// </summary>
[Serializable]
public record LogSecurityContext : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// JA3 fingerprint value.
    /// </summary>
    [Optional]
    [JsonPropertyName("ja3")]
    public string? Ja3 { get; set; }

    /// <summary>
    /// JA4 fingerprint value.
    /// </summary>
    [Optional]
    [JsonPropertyName("ja4")]
    public string? Ja4 { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
