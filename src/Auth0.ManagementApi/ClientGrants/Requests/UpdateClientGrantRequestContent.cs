using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateClientGrantRequestContent
{
    /// <summary>
    /// Scopes allowed for this client grant.
    /// </summary>
    [Optional]
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("organization_usage")]
    public Optional<ClientGrantOrganizationNullableUsageEnum?> OrganizationUsage { get; set; }

    /// <summary>
    /// Controls allowing any organization to be used with this grant
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("allow_any_organization")]
    public Optional<bool?> AllowAnyOrganization { get; set; }

    /// <summary>
    /// Types of authorization_details allowed for this client grant. Use of this field is subject to the applicable Free Trial terms in Okta’s <a href= "https://www.okta.com/legal/"> Master Subscription Agreement.</a>
    /// </summary>
    [Optional]
    [JsonPropertyName("authorization_details_types")]
    public IEnumerable<string>? AuthorizationDetailsTypes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
