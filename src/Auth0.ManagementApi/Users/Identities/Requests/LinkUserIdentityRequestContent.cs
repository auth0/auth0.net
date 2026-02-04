using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

[Serializable]
public record LinkUserIdentityRequestContent
{
    [Optional]
    [JsonPropertyName("provider")]
    public UserIdentityProviderEnum? Provider { get; set; }

    /// <summary>
    /// connection_id of the secondary user account being linked when more than one `auth0` database provider exists.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    [Optional]
    [JsonPropertyName("user_id")]
    public UserId? UserId { get; set; }

    /// <summary>
    /// JWT for the secondary account being linked. If sending this parameter, `provider`, `user_id`, and `connection_id` must not be sent.
    /// </summary>
    [Optional]
    [JsonPropertyName("link_with")]
    public string? LinkWith { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
