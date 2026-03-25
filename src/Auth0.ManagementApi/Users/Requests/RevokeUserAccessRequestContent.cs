using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record RevokeUserAccessRequestContent
{
    /// <summary>
    /// ID of the session to revoke.
    /// </summary>
    [Optional]
    [JsonPropertyName("session_id")]
    public string? SessionId { get; set; }

    /// <summary>
    /// Whether to preserve the refresh tokens associated with the session.
    /// </summary>
    [Optional]
    [JsonPropertyName("preserve_refresh_tokens")]
    public bool? PreserveRefreshTokens { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
