using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record NetworkAclMatch : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("asns")]
    public IEnumerable<int>? Asns { get; set; }

    [Optional]
    [JsonPropertyName("geo_country_codes")]
    public IEnumerable<string>? GeoCountryCodes { get; set; }

    [Optional]
    [JsonPropertyName("geo_subdivision_codes")]
    public IEnumerable<string>? GeoSubdivisionCodes { get; set; }

    [Optional]
    [JsonPropertyName("ipv4_cidrs")]
    public IEnumerable<string>? Ipv4Cidrs { get; set; }

    [Optional]
    [JsonPropertyName("ipv6_cidrs")]
    public IEnumerable<string>? Ipv6Cidrs { get; set; }

    [Optional]
    [JsonPropertyName("ja3_fingerprints")]
    public IEnumerable<string>? Ja3Fingerprints { get; set; }

    [Optional]
    [JsonPropertyName("ja4_fingerprints")]
    public IEnumerable<string>? Ja4Fingerprints { get; set; }

    [Optional]
    [JsonPropertyName("user_agents")]
    public IEnumerable<string>? UserAgents { get; set; }

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
