using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateSessionRequestContent
{
    [Nullable, Optional]
    [JsonPropertyName("session_metadata")]
    public Optional<Dictionary<string, object?>?> SessionMetadata { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
