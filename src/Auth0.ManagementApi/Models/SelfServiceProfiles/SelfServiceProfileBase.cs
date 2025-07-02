using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.SelfServiceProfiles;

/// <summary>
/// Represents the Self Service Profile.
/// </summary>
public class SelfServiceProfileBase
{
    /// <summary>
    /// Name of the self-service profile.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
        
    /// <summary>
    /// Description of the self-service profile.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; }
        
    /// <inheritdoc cref="Auth0.ManagementApi.Models.SelfServiceProfiles.UserAttribute"/>
    [JsonProperty("user_attributes")]
    public IList<UserAttribute> UserAttributes { get; set; }
        
    [JsonProperty("branding")]
    public Branding Branding { get; set; }
        
    /// <summary>
    /// List of IdP strategies that will be shown to users during the Self-Service SSO flow.
    /// Possible values: [oidc, samlp, waad, google-apps, adfs, okta, keycloak-samlp, pingfederate]
    /// </summary>
    [JsonProperty("allowed_strategies")]
    public string[] AllowedStrategies { get; set; }
}