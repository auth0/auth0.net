using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Color scheme used to customize the login pages.
/// </summary>
[Serializable]
public record EventStreamCloudEventOrgUpdatedObjectBrandingColors : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// HEX Color for primary elements.
    /// </summary>
    [Optional]
    [JsonPropertyName("primary")]
    public string? Primary { get; set; }

    /// <summary>
    /// HEX Color for background.
    /// </summary>
    [Optional]
    [JsonPropertyName("page_background")]
    public string? PageBackground { get; set; }

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
