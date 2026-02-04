using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record CreateOrganizationDiscoveryDomainRequestContent
{
    /// <summary>
    /// The domain name to associate with the organization e.g. acme.com.
    /// </summary>
    [JsonPropertyName("domain")]
    public required string Domain { get; set; }

    [Optional]
    [JsonPropertyName("status")]
    public OrganizationDiscoveryDomainStatus? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
