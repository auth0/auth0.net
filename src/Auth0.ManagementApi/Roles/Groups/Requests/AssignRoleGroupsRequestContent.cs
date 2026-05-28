using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Roles;

[Serializable]
public record AssignRoleGroupsRequestContent
{
    /// <summary>
    /// Array of group IDs to assign to the role.
    /// </summary>
    [JsonPropertyName("groups")]
    public IEnumerable<string> Groups { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
