using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateSelfServiceProfileRequestContent
{
    /// <summary>
    /// The name of the self-service Profile.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The description of the self-service Profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

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
    /// List of attributes to be mapped that will be shown to the user during the SS-SSO flow.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_attributes")]
    public IEnumerable<SelfServiceProfileUserAttribute>? UserAttributes { get; set; }

    /// <summary>
    /// ID of the user-attribute-profile to associate with this self-service profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_attribute_profile_id")]
    public string? UserAttributeProfileId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
