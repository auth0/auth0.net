using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Users.EffectiveRoles.Sources;

[Serializable]
public record ListUserRoleSourceGroupsRequestParameters
{
    /// <summary>
    /// ID of the role to get source groups for.
    /// </summary>
    [JsonIgnore]
    public required string RoleId { get; set; }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
