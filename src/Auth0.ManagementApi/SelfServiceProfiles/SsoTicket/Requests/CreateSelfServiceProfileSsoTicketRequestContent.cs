using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.SelfServiceProfiles;

[Serializable]
public record CreateSelfServiceProfileSsoTicketRequestContent
{
    /// <summary>
    /// If provided, this will allow editing of the provided connection during the SSO Flow
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    [Optional]
    [JsonPropertyName("connection_config")]
    public SelfServiceProfileSsoTicketConnectionConfig? ConnectionConfig { get; set; }

    /// <summary>
    /// List of client_ids that the connection will be enabled for.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled_clients")]
    public IEnumerable<string>? EnabledClients { get; set; }

    /// <summary>
    /// List of organizations that the connection will be enabled for.
    /// </summary>
    [Optional]
    [JsonPropertyName("enabled_organizations")]
    public IEnumerable<SelfServiceProfileSsoTicketEnabledOrganization>? EnabledOrganizations { get; set; }

    /// <summary>
    /// Number of seconds for which the ticket is valid before expiration. If unspecified or set to 0, this value defaults to 432000 seconds (5 days).
    /// </summary>
    [Optional]
    [JsonPropertyName("ttl_sec")]
    public int? TtlSec { get; set; }

    [Optional]
    [JsonPropertyName("domain_aliases_config")]
    public SelfServiceProfileSsoTicketDomainAliasesConfig? DomainAliasesConfig { get; set; }

    [Optional]
    [JsonPropertyName("provisioning_config")]
    public SelfServiceProfileSsoTicketProvisioningConfig? ProvisioningConfig { get; set; }

    /// <summary>
    /// Indicates whether a verified domain should be used for organization discovery during authentication.
    /// </summary>
    [Optional]
    [JsonPropertyName("use_for_organization_discovery")]
    public bool? UseForOrganizationDiscovery { get; set; }

    [Optional]
    [JsonPropertyName("enabled_features")]
    public SelfServiceProfileSsoTicketEnabledFeatures? EnabledFeatures { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
