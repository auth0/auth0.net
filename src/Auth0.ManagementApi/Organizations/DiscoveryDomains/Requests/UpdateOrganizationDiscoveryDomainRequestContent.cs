using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record UpdateOrganizationDiscoveryDomainRequestContent
{
    [Optional]
    [JsonPropertyName("status")]
    public OrganizationDiscoveryDomainStatus? Status { get; set; }

    /// <summary>
    /// Indicates whether this domain should be used for organization discovery.
    /// </summary>
    [Optional]
    [JsonPropertyName("use_for_organization_discovery")]
    public bool? UseForOrganizationDiscovery { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
