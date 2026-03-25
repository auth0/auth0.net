using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateUserAttributeProfileRequestContent
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [Optional]
    [JsonPropertyName("user_id")]
    public UserAttributeProfileUserId? UserId { get; set; }

    [JsonPropertyName("user_attributes")]
    public Dictionary<
        string,
        UserAttributeProfileUserAttributeAdditionalProperties
    > UserAttributes { get; set; } =
        new Dictionary<string, UserAttributeProfileUserAttributeAdditionalProperties>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
