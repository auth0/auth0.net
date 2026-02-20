using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Information about the location that triggered this event based on the `ip`.
/// </summary>
[Serializable]
public record LogLocationInfo : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Two-letter <see href="https://www.iso.org/iso-3166-country-codes.html">Alpha-2 ISO 3166-1</see> country code.
    /// </summary>
    [Optional]
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Three-letter <see href="https://www.iso.org/iso-3166-country-codes.html">Alpha-3 ISO 3166-1</see> country code.
    /// </summary>
    [Optional]
    [JsonPropertyName("country_code3")]
    public string? CountryCode3 { get; set; }

    /// <summary>
    /// Full country name in English.
    /// </summary>
    [Optional]
    [JsonPropertyName("country_name")]
    public string? CountryName { get; set; }

    /// <summary>
    /// Full city name in English.
    /// </summary>
    [Optional]
    [JsonPropertyName("city_name")]
    public string? CityName { get; set; }

    /// <summary>
    /// Global latitude (horizontal) position.
    /// </summary>
    [Optional]
    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    /// <summary>
    /// Global longitude (vertical) position.
    /// </summary>
    [Optional]
    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }

    /// <summary>
    /// Time zone name as found in the <see href="https://www.iana.org/time-zones">tz database</see>.
    /// </summary>
    [Optional]
    [JsonPropertyName("time_zone")]
    public string? TimeZone { get; set; }

    /// <summary>
    /// Continent the country is located within. Can be `AF` (Africa), `AN` (Antarctica), `AS` (Asia), `EU` (Europe), `NA` (North America), `OC` (Oceania) or `SA` (South America).
    /// </summary>
    [Optional]
    [JsonPropertyName("continent_code")]
    public string? ContinentCode { get; set; }

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
