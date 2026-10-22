using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ConsentSigningKey : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The key identifier of the consent signing key.
    /// </summary>
    [JsonPropertyName("kid")]
    public required string Kid { get; set; }

    /// <summary>
    /// A human-readable label for the device holding the corresponding private key.
    /// </summary>
    [JsonPropertyName("device_identifier")]
    public required string DeviceIdentifier { get; set; }

    /// <summary>
    /// The ISO 8601 timestamp at which the key was registered.
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 timestamp at which the key expires and can no longer be used to verify consent decisions.
    /// </summary>
    [JsonPropertyName("expires_at")]
    public required DateTime ExpiresAt { get; set; }

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
