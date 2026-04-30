using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Geographic information about the request origin.
/// </summary>
[Serializable]
public record EventStreamCloudEventContextRequestGeo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Continent code.
    /// </summary>
    [Optional]
    [JsonPropertyName("continent_code")]
    public string? ContinentCode { get; set; }

    /// <summary>
    /// Country code.
    /// </summary>
    [Optional]
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Country name.
    /// </summary>
    [Optional]
    [JsonPropertyName("country_name")]
    public string? CountryName { get; set; }

    /// <summary>
    /// Latitude coordinate.
    /// </summary>
    [Optional]
    [JsonPropertyName("latitude")]
    public double? Latitude { get; set; }

    /// <summary>
    /// Longitude coordinate.
    /// </summary>
    [Optional]
    [JsonPropertyName("longitude")]
    public double? Longitude { get; set; }

    /// <summary>
    /// Subdivision (state/province) code.
    /// </summary>
    [Optional]
    [JsonPropertyName("subdivision_code")]
    public string? SubdivisionCode { get; set; }

    /// <summary>
    /// Subdivision (state/province) name.
    /// </summary>
    [Optional]
    [JsonPropertyName("subdivision_name")]
    public string? SubdivisionName { get; set; }

    /// <summary>
    /// City name.
    /// </summary>
    [Optional]
    [JsonPropertyName("city_name")]
    public string? CityName { get; set; }

    /// <summary>
    /// Time zone.
    /// </summary>
    [Optional]
    [JsonPropertyName("time_zone")]
    public string? TimeZone { get; set; }

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
