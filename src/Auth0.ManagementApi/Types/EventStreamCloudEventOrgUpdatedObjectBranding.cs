using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The branding associated with the organization.
/// </summary>
[Serializable]
public record EventStreamCloudEventOrgUpdatedObjectBranding : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// URL of logo to display on login page.
    /// </summary>
    [Optional]
    [JsonPropertyName("logo_url")]
    public string? LogoUrl { get; set; }

    [Optional]
    [JsonPropertyName("colors")]
    public EventStreamCloudEventOrgUpdatedObjectBrandingColors? Colors { get; set; }

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
