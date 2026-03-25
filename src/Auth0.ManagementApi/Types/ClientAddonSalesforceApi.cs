using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Salesforce API addon configuration.
/// </summary>
[Serializable]
public record ClientAddonSalesforceApi : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Consumer Key assigned by Salesforce to the Connected App.
    /// </summary>
    [Optional]
    [JsonPropertyName("clientid")]
    public string? Clientid { get; set; }

    /// <summary>
    /// Name of the property in the user object that maps to a Salesforce username. e.g. `email`.
    /// </summary>
    [Optional]
    [JsonPropertyName("principal")]
    public string? Principal { get; set; }

    /// <summary>
    /// Community name.
    /// </summary>
    [Optional]
    [JsonPropertyName("communityName")]
    public string? CommunityName { get; set; }

    /// <summary>
    /// Community url section.
    /// </summary>
    [Optional]
    [JsonPropertyName("community_url_section")]
    public string? CommunityUrlSection { get; set; }

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
