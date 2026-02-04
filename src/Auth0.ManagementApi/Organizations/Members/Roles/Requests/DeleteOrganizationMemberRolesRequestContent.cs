using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Organizations.Members;

[Serializable]
public record DeleteOrganizationMemberRolesRequestContent
{
    /// <summary>
    /// List of roles IDs associated with the organization member to remove.
    /// </summary>
    [JsonPropertyName("roles")]
    public IEnumerable<string> Roles { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
