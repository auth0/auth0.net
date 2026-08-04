using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateRoleRequestContent
{
    /// <summary>
    /// Name of the role.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Description of the role.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The type of the role. Defaults to tenant.
    /// </summary>
    [Optional]
    [JsonPropertyName("type")]
    public RoleTypeEnum? Type { get; set; }

    /// <summary>
    /// The ID of the organization that owns this role. Required when type is "organization".
    /// </summary>
    [Optional]
    [JsonPropertyName("owner_id")]
    public string? OwnerId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
