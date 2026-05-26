using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Groups;

[Serializable]
public record DeleteGroupRolesRequestContent
{
    /// <summary>
    /// Array of role IDs to remove from the group.
    /// </summary>
    [JsonPropertyName("roles")]
    public IEnumerable<string> Roles { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
