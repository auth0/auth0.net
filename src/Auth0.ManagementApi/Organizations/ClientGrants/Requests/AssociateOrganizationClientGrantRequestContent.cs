using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record AssociateOrganizationClientGrantRequestContent
{
    /// <summary>
    /// A Client Grant ID to add to the organization.
    /// </summary>
    [JsonPropertyName("grant_id")]
    public required string GrantId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
