using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Encryption key
/// </summary>
[Serializable]
public record EncryptionKey : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Key ID
    /// </summary>
    [JsonPropertyName("kid")]
    public required string Kid { get; set; }

    [JsonPropertyName("type")]
    public required EncryptionKeyType Type { get; set; }

    [JsonPropertyName("state")]
    public required EncryptionKeyState State { get; set; }

    /// <summary>
    /// Key creation timestamp
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Key update timestamp
    /// </summary>
    [JsonPropertyName("updated_at")]
    public required DateTime UpdatedAt { get; set; }

    /// <summary>
    /// ID of parent wrapping key
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("parent_kid")]
    public Optional<string?> ParentKid { get; set; }

    /// <summary>
    /// Public key in PEM format
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("public_key")]
    public Optional<string?> PublicKey { get; set; }

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
