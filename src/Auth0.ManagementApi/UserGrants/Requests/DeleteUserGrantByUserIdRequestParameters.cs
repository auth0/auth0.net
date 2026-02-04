using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record DeleteUserGrantByUserIdRequestParameters
{
    /// <summary>
    /// user_id of the grant to delete.
    /// </summary>
    [JsonIgnore]
    public required string UserId { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
