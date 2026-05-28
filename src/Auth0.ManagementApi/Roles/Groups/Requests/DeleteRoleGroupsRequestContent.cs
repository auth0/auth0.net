using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Roles;

[Serializable]
public record DeleteRoleGroupsRequestContent
{
    /// <summary>
    /// Array of group IDs to remove from the role.
    /// </summary>
    [JsonPropertyName("groups")]
    public IEnumerable<string> Groups { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
