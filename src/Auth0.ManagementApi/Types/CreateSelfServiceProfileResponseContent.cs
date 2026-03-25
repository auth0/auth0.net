using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateSelfServiceProfileResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique ID of the self-service Profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// The name of the self-service Profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The description of the self-service Profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// List of attributes to be mapped that will be shown to the user during the SS-SSO flow.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_attributes")]
    public IEnumerable<SelfServiceProfileUserAttribute>? UserAttributes { get; set; }

    /// <summary>
    /// The time when this self-service Profile was created.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The time when this self-service Profile was updated.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    [Optional]
    [JsonPropertyName("branding")]
    public SelfServiceProfileBrandingProperties? Branding { get; set; }

    /// <summary>
    /// List of IdP strategies that will be shown to users during the Self-Service SSO flow. Possible values: [`oidc`, `samlp`, `waad`, `google-apps`, `adfs`, `okta`, `auth0-samlp`, `okta-samlp`, `keycloak-samlp`, `pingfederate`]
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_strategies")]
    public IEnumerable<SelfServiceProfileAllowedStrategyEnum>? AllowedStrategies { get; set; }

    /// <summary>
    /// ID of the user-attribute-profile to associate with this self-service profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_attribute_profile_id")]
    public string? UserAttributeProfileId { get; set; }

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
