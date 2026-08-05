using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Metadata about the associated client.
/// </summary>
[Serializable]
public record OrganizationClientMetadata : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The name of the client.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The type of the client application.
    /// </summary>
    [Optional]
    [JsonPropertyName("app_type")]
    public string? AppType { get; set; }

    /// <summary>
    /// The URI of the client logo.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("logo_uri")]
    public Optional<string?> LogoUri { get; set; }

    /// <summary>
    /// Whether this client is a first-party client (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("is_first_party")]
    public bool? IsFirstParty { get; set; }

    /// <summary>
    /// The grant types enabled for the client.
    /// </summary>
    [Optional]
    [JsonPropertyName("grant_types")]
    public IEnumerable<string>? GrantTypes { get; set; }

    [Optional]
    [JsonPropertyName("organization_usage")]
    public OrganizationClientMetadataOrganizationUsageEnum? OrganizationUsage { get; set; }

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
