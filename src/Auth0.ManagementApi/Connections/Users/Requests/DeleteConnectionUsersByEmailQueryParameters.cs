using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Connections;

[Serializable]
public record DeleteConnectionUsersByEmailQueryParameters
{
    /// <summary>
    /// The email of the user to delete
    /// </summary>
    [JsonIgnore]
    public required string Email { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
