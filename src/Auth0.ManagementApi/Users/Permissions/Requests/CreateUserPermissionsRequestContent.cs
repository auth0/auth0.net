using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Users;

[Serializable]
public record CreateUserPermissionsRequestContent
{
    /// <summary>
    /// List of permissions to add to this user.
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
