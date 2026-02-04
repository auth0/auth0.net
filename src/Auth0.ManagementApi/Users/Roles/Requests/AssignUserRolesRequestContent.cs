using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

[Serializable]
public record AssignUserRolesRequestContent
{
    /// <summary>
    /// List of roles IDs to associated with the user.
    /// </summary>
    [JsonPropertyName("roles")]
    public IEnumerable<string> Roles { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
