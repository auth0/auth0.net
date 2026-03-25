using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateClientGrantRequestContent
{
    /// <summary>
    /// Scopes allowed for this client grant.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("scope")]
    public Optional<IEnumerable<string>?> Scope { get; set; }

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
    /// Types of authorization_details allowed for this client grant.
    /// </summary>
    [Optional]
    [JsonPropertyName("authorization_details_types")]
    public IEnumerable<string>? AuthorizationDetailsTypes { get; set; }

    /// <summary>
    /// If enabled, all scopes configured on the resource server are allowed for this grant.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("allow_all_scopes")]
    public Optional<bool?> AllowAllScopes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
