using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

[Serializable]
public record DeleteUserPermissionsRequestContent
{
    /// <summary>
    /// List of permissions to remove from this user.
    /// </summary>
    [JsonPropertyName("permissions")]
    public IEnumerable<PermissionRequestPayload> Permissions { get; set; } =
        new List<PermissionRequestPayload>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
