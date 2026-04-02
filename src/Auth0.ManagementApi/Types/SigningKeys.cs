using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record SigningKeys : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The key id of the signing key
    /// </summary>
    [JsonPropertyName("kid")]
    public required string Kid { get; set; }

    /// <summary>
    /// The public certificate of the signing key
    /// </summary>
    [JsonPropertyName("cert")]
    public required string Cert { get; set; }

    /// <summary>
    /// The public certificate of the signing key in pkcs7 format
    /// </summary>
    [Optional]
    [JsonPropertyName("pkcs7")]
    public string? Pkcs7 { get; set; }

    /// <summary>
    /// True if the key is the the current key
    /// </summary>
    [Optional]
    [JsonPropertyName("current")]
    public bool? Current { get; set; }

    /// <summary>
    /// True if the key is the the next key
    /// </summary>
    [Optional]
    [JsonPropertyName("next")]
    public bool? Next { get; set; }

    /// <summary>
    /// True if the key is the the previous key
    /// </summary>
    [Optional]
    [JsonPropertyName("previous")]
    public bool? Previous { get; set; }

    [Optional]
    [JsonPropertyName("current_since")]
    public SigningKeysDate? CurrentSince { get; set; }

    [Optional]
    [JsonPropertyName("current_until")]
    public SigningKeysDate? CurrentUntil { get; set; }

    /// <summary>
    /// The cert fingerprint
    /// </summary>
    [JsonPropertyName("fingerprint")]
    public required string Fingerprint { get; set; }

    /// <summary>
    /// The cert thumbprint
    /// </summary>
    [JsonPropertyName("thumbprint")]
    public required string Thumbprint { get; set; }

    /// <summary>
    /// True if the key is revoked
    /// </summary>
    [Optional]
    [JsonPropertyName("revoked")]
    public bool? Revoked { get; set; }

    [Optional]
    [JsonPropertyName("revoked_at")]
    public SigningKeysDate? RevokedAt { get; set; }

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
