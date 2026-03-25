using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record RefreshTokenResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// The ID of the refresh token
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
    public RefreshTokenDate? CreatedAt { get; set; }

    [Optional]
    [JsonPropertyName("idle_expires_at")]
    public RefreshTokenDate? IdleExpiresAt { get; set; }

    [Optional]
    [JsonPropertyName("expires_at")]
    public RefreshTokenDate? ExpiresAt { get; set; }

    [Optional]
    [JsonPropertyName("device")]
    public RefreshTokenDevice? Device { get; set; }

    /// <summary>
    /// ID of the client application granted with this refresh token
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("session_id")]
    public Optional<string?> SessionId { get; set; }

    /// <summary>
    /// True if the token is a rotating refresh token
    /// </summary>
    [Optional]
    [JsonPropertyName("rotating")]
    public bool? Rotating { get; set; }

    /// <summary>
    /// A list of the resource server IDs associated to this refresh-token and their granted scopes
    /// </summary>
    [Optional]
    [JsonPropertyName("resource_servers")]
    public IEnumerable<RefreshTokenResourceServer>? ResourceServers { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("refresh_token_metadata")]
    public Optional<Dictionary<string, object?>?> RefreshTokenMetadata { get; set; }

    [Optional]
    [JsonPropertyName("last_exchanged_at")]
    public RefreshTokenDate? LastExchangedAt { get; set; }

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
