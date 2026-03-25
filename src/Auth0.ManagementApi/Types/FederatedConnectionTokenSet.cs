using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FederatedConnectionTokenSet : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [Optional]
    [JsonPropertyName("connection")]
    public string? Connection { get; set; }

    [Optional]
    [JsonPropertyName("scope")]
    public string? Scope { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("expires_at")]
    public Optional<DateTime?> ExpiresAt { get; set; }

    [Optional]
    [JsonPropertyName("issued_at")]
    public DateTime? IssuedAt { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("last_used_at")]
    public Optional<DateTime?> LastUsedAt { get; set; }

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
