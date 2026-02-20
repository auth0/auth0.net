using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateSelfServiceProfileRequestContent
{
    /// <summary>
    /// The name of the self-service Profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("description")]
    public Optional<string?> Description { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("branding")]
    public Optional<SelfServiceProfileBrandingProperties?> Branding { get; set; }

    /// <summary>
    /// List of IdP strategies that will be shown to users during the Self-Service SSO flow. Possible values: [`oidc`, `samlp`, `waad`, `google-apps`, `adfs`, `okta`, `auth0-samlp`, `okta-samlp`, `keycloak-samlp`, `pingfederate`]
    /// </summary>
    [Optional]
    [JsonPropertyName("allowed_strategies")]
    public IEnumerable<SelfServiceProfileAllowedStrategyEnum>? AllowedStrategies { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("user_attributes")]
    public Optional<IEnumerable<SelfServiceProfileUserAttribute>?> UserAttributes { get; set; }

    /// <summary>
    /// ID of the user-attribute-profile to associate with this self-service profile.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("user_attribute_profile_id")]
    public Optional<string?> UserAttributeProfileId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
