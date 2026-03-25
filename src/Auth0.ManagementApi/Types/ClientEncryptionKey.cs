using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Encryption used for WsFed responses with this client.
/// </summary>
[Serializable]
public record ClientEncryptionKey : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Encryption Public RSA Key.
    /// </summary>
    [Optional]
    [JsonPropertyName("pub")]
    public string? Pub { get; set; }

    /// <summary>
    /// Encryption certificate for public key in X.509 (.CER) format.
    /// </summary>
    [Optional]
    [JsonPropertyName("cert")]
    public string? Cert { get; set; }

    /// <summary>
    /// Encryption certificate name for this certificate in the format `/CN={domain}`.
    /// </summary>
    [Optional]
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

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
