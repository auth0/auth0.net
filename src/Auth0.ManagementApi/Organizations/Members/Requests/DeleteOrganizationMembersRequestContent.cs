using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record DeleteOrganizationMembersRequestContent
{
    /// <summary>
    /// List of user IDs to remove from the organization.
    /// </summary>
    [JsonPropertyName("members")]
    public IEnumerable<string> Members { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
