using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Roles;

[Serializable]
public record AddRolePermissionsRequestContent
{
    /// <summary>
    /// array of resource_server_identifier, permission_name pairs.
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
