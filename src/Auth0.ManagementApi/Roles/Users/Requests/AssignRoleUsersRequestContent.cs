using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Roles;

[Serializable]
public record AssignRoleUsersRequestContent
{
    /// <summary>
    /// user_id's of the users to assign the role to.
    /// </summary>
    [JsonPropertyName("users")]
    public IEnumerable<string> Users { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
