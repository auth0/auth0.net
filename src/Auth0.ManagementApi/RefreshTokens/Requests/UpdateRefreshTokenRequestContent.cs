using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateRefreshTokenRequestContent
{
    /// <summary>
    /// Metadata associated with the refresh token. Pass null or {} to remove all metadata.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("refresh_token_metadata")]
    public Optional<Dictionary<string, object?>?> RefreshTokenMetadata { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
