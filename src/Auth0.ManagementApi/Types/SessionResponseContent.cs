using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record SessionResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The ID of the session
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// ID of the user which can be used when interacting with other APIs.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    [Optional]
    [JsonPropertyName("created_at")]
    public SessionDate? CreatedAt { get; set; }

    [Optional]
    [JsonPropertyName("updated_at")]
    public SessionDate? UpdatedAt { get; set; }

    [Optional]
    [JsonPropertyName("authenticated_at")]
    public SessionDate? AuthenticatedAt { get; set; }

    [Optional]
    [JsonPropertyName("idle_expires_at")]
    public SessionDate? IdleExpiresAt { get; set; }

    [Optional]
    [JsonPropertyName("expires_at")]
    public SessionDate? ExpiresAt { get; set; }

    [Optional]
    [JsonPropertyName("last_interacted_at")]
    public SessionDate? LastInteractedAt { get; set; }

    [Optional]
    [JsonPropertyName("device")]
    public SessionDeviceMetadata? Device { get; set; }

    /// <summary>
    /// List of client details for the session
    /// </summary>
    [Optional]
    [JsonPropertyName("clients")]
    public IEnumerable<SessionClientMetadata>? Clients { get; set; }

    [Optional]
    [JsonPropertyName("authentication")]
    public SessionAuthenticationSignals? Authentication { get; set; }

    [Optional]
    [JsonPropertyName("cookie")]
    public SessionCookieMetadata? Cookie { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("session_metadata")]
    public Optional<Dictionary<string, object?>?> SessionMetadata { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
