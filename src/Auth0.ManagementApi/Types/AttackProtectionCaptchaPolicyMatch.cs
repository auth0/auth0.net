using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Traffic matching criteria for the policy. Exactly one of auth0_managed or geo_country_codes must be specified.
/// </summary>
[Serializable]
public record AttackProtectionCaptchaPolicyMatch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Match by Auth0-managed traffic identifiers.
    /// </summary>
    [Optional]
    [JsonPropertyName("auth0_managed")]
    public IEnumerable<string>? Auth0Managed { get; set; }

    /// <summary>
    /// Match by ISO 3166-1 alpha-2 country codes.
    /// </summary>
    [Optional]
    [JsonPropertyName("geo_country_codes")]
    public IEnumerable<string>? GeoCountryCodes { get; set; }

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
