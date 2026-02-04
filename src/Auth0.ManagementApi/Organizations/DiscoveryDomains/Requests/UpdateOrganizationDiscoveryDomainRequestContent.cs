using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record UpdateOrganizationDiscoveryDomainRequestContent
{
    [Optional]
    [JsonPropertyName("status")]
    public OrganizationDiscoveryDomainStatus? Status { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
