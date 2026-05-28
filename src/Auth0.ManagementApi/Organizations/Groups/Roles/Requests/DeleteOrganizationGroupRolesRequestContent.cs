using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Organizations.Groups;

[Serializable]
public record DeleteOrganizationGroupRolesRequestContent
{
    /// <summary>
    /// Array of role IDs to delete from organization group.
    /// </summary>
    [JsonPropertyName("roles")]
    public IEnumerable<string> Roles { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
