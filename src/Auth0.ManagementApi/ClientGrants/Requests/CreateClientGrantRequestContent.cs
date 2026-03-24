using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateClientGrantRequestContent
{
    /// <summary>
    /// ID of the client.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// The audience (API identifier) of this client grant
    /// </summary>
    [JsonPropertyName("audience")]
    public required string Audience { get; set; }

    [Optional]
    [JsonPropertyName("organization_usage")]
    public ClientGrantOrganizationUsageEnum? OrganizationUsage { get; set; }

    /// <summary>
    /// If enabled, any organization can be used with this grant. If disabled (default), the grant must be explicitly assigned to the desired organizations.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_any_organization")]
    public bool? AllowAnyOrganization { get; set; }

    /// <summary>
    /// Scopes allowed for this client grant.
    /// </summary>
    [Optional]
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Optional]
    [JsonPropertyName("subject_type")]
    public ClientGrantSubjectTypeEnum? SubjectType { get; set; }

    /// <summary>
    /// Types of authorization_details allowed for this client grant.
    /// </summary>
    [Optional]
    [JsonPropertyName("authorization_details_types")]
    public IEnumerable<string>? AuthorizationDetailsTypes { get; set; }

    /// <summary>
    /// If enabled, all scopes configured on the resource server are allowed for this grant.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_all_scopes")]
    public bool? AllowAllScopes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
