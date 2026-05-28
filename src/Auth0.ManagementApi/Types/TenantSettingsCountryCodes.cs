using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Phone country code configuration for identifier input.
/// </summary>
[Serializable]
public record TenantSettingsCountryCodes : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Array of ISO 3166-1 alpha-2 country codes.
    /// </summary>
    [Optional]
    [JsonPropertyName("list")]
    public IEnumerable<string>? List { get; set; }

    [Optional]
    [JsonPropertyName("mode")]
    public TenantSettingsCountryCodesMode? Mode { get; set; }

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
