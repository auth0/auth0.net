using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateRefreshTokenRequestContent
{
    [Nullable, Optional]
    [JsonPropertyName("refresh_token_metadata")]
    public Optional<Dictionary<string, object?>?> RefreshTokenMetadata { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
