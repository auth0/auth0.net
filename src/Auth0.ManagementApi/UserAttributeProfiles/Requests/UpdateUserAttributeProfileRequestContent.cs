using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateUserAttributeProfileRequestContent
{
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("user_id")]
    public Optional<UserAttributeProfileUserId?> UserId { get; set; }

    [Optional]
    [JsonPropertyName("user_attributes")]
    public Dictionary<
        string,
        UserAttributeProfileUserAttributeAdditionalProperties
    >? UserAttributes { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
