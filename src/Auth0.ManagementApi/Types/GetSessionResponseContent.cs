using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetSessionResponseContent : IJsonOnDeserialized, IJsonOnSerializing
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

    [Nullable, Optional]
    [JsonPropertyName("created_at")]
    public Optional<SessionDate?> CreatedAt { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("updated_at")]
    public Optional<SessionDate?> UpdatedAt { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("authenticated_at")]
    public Optional<SessionDate?> AuthenticatedAt { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("idle_expires_at")]
    public Optional<SessionDate?> IdleExpiresAt { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("expires_at")]
    public Optional<SessionDate?> ExpiresAt { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("last_interacted_at")]
    public Optional<SessionDate?> LastInteractedAt { get; set; }

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

    [Optional]
    [JsonPropertyName("actor")]
    public SessionActorMetadata? Actor { get; set; }

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
