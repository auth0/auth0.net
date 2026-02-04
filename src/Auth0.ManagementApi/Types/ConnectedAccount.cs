using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ConnectedAccount : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique identifier for the connected account.
    /// </summary>
    [JsonPropertyName("id")]
    public required string Id { get; set; }

    /// <summary>
    /// The name of the connection associated with the account.
    /// </summary>
    [JsonPropertyName("connection")]
    public required string Connection { get; set; }

    /// <summary>
    /// The unique identifier of the connection associated with the account.
    /// </summary>
    [JsonPropertyName("connection_id")]
    public required string ConnectionId { get; set; }

    /// <summary>
    /// The authentication strategy used by the connection.
    /// </summary>
    [JsonPropertyName("strategy")]
    public required string Strategy { get; set; }

    [JsonPropertyName("access_type")]
    public string AccessType { get; set; } = "offline";

    /// <summary>
    /// The scopes granted for this connected account.
    /// </summary>
    [Optional]
    [JsonPropertyName("scopes")]
    public IEnumerable<string>? Scopes { get; set; }

    /// <summary>
    /// ISO 8601 timestamp when the connected account was created.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// ISO 8601 timestamp when the connected account expires.
    /// </summary>
    [Optional]
    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
