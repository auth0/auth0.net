using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Users.EffectivePermissions.Sources;

[Serializable]
public record ListUserEffectivePermissionRoleSourceRequestParameters
{
    /// <summary>
    /// Optional Id from which to start selection.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Number of results per page. Defaults to 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <summary>
    /// The identifier of the resource server for which to calculate user permissions.
    /// </summary>
    [JsonIgnore]
    public required string ResourceServerIdentifier { get; set; }

    /// <summary>
    /// Name of this permission
    /// </summary>
    [JsonIgnore]
    public required string PermissionName { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
