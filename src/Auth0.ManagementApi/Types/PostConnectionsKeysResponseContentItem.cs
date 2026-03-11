using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record PostConnectionsKeysResponseContentItem : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

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
    [JsonPropertyName("pkcs")]
    public string? Pkcs { get; set; }

    /// <summary>
    /// True if the key is the current key
    /// </summary>
    [Optional]
    [JsonPropertyName("current")]
    public bool? Current { get; set; }

    /// <summary>
    /// True if the key is the next key
    /// </summary>
    [Optional]
    [JsonPropertyName("next")]
    public bool? Next { get; set; }

    /// <summary>
    /// The date and time when the key became the current key
    /// </summary>
    [Optional]
    [JsonPropertyName("current_since")]
    public string? CurrentSince { get; set; }

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
    /// Signing key algorithm
    /// </summary>
    [Optional]
    [JsonPropertyName("algorithm")]
    public string? Algorithm { get; set; }

    [Optional]
    [JsonPropertyName("key_use")]
    public ConnectionKeyUseEnum? KeyUse { get; set; }

    [Optional]
    [JsonPropertyName("subject_dn")]
    public string? SubjectDn { get; set; }

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
