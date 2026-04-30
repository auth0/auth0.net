using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetBrandingResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("colors")]
    public BrandingColors? Colors { get; set; }

    /// <summary>
    /// URL for the favicon. Must use HTTPS.
    /// </summary>
    [Optional]
    [JsonPropertyName("favicon_url")]
    public string? FaviconUrl { get; set; }

    /// <summary>
    /// URL for the logo. Must use HTTPS.
    /// </summary>
    [Optional]
    [JsonPropertyName("logo_url")]
    public string? LogoUrl { get; set; }

    [Optional]
    [JsonPropertyName("identifiers")]
    public BrandingIdentifiers? Identifiers { get; set; }

    [Optional]
    [JsonPropertyName("font")]
    public BrandingFont? Font { get; set; }

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
