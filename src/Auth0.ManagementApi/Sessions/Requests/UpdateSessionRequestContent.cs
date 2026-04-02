using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateSessionRequestContent
{
    /// <summary>
    /// Metadata associated with the session. Pass null or {} to remove all session_metadata.
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("session_metadata")]
    public Optional<Dictionary<string, object?>?> SessionMetadata { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
