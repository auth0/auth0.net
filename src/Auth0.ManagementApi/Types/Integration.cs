using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Integration defines a self contained functioning unit which partners
/// publish. A partner may create one or many of these integrations.
/// </summary>
[Serializable]
public record Integration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// id is a system generated GUID. This same ID is designed to be federated in
    /// all the applicable localities.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// catalog_id refers to the ID in the marketplace catalog
    /// </summary>
    [Optional]
    [JsonPropertyName("catalog_id")]
    public string? CatalogId { get; set; }

    /// <summary>
    /// url_slug refers to the url_slug in the marketplace catalog
    /// </summary>
    [Optional]
    [JsonPropertyName("url_slug")]
    public string? UrlSlug { get; set; }

    /// <summary>
    /// partner_id is the foreign key reference to the partner account this
    /// integration belongs to.
    /// </summary>
    [Optional]
    [JsonPropertyName("partner_id")]
    public string? PartnerId { get; set; }

    /// <summary>
    /// name is the integration name, which will be used for display purposes in
    /// the marketplace.
    ///
    /// To start we're going to make sure the display name is at least 3
    /// characters. Can adjust this easily later.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// description adds more text for the integration name -- also relevant for
    /// the marketplace listing.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// short_description is the brief description of the integration, which is used for display purposes in cards
    /// </summary>
    [Optional]
    [JsonPropertyName("short_description")]
    public string? ShortDescription { get; set; }

    [Optional]
    [JsonPropertyName("logo")]
    public string? Logo { get; set; }

    [Optional]
    [JsonPropertyName("feature_type")]
    public IntegrationFeatureTypeEnum? FeatureType { get; set; }

    [Optional]
    [JsonPropertyName("terms_of_use_url")]
    public string? TermsOfUseUrl { get; set; }

    [Optional]
    [JsonPropertyName("privacy_policy_url")]
    public string? PrivacyPolicyUrl { get; set; }

    [Optional]
    [JsonPropertyName("public_support_link")]
    public string? PublicSupportLink { get; set; }

    [Optional]
    [JsonPropertyName("current_release")]
    public IntegrationRelease? CurrentRelease { get; set; }

    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

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
