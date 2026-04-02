using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Device Flow configuration
/// </summary>
[Serializable]
public record TenantSettingsDeviceFlow : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("charset")]
    public TenantSettingsDeviceFlowCharset? Charset { get; set; }

    /// <summary>
    /// Mask used to format a generated User Code into a friendly, readable format.
    /// </summary>
    [Optional]
    [JsonPropertyName("mask")]
    public string? Mask { get; set; }

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
