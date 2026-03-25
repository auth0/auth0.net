using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ClientSigningKey : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Signing certificate public key and chain in PKCS#7 (.P7B) format.
    /// </summary>
    [Optional]
    [JsonPropertyName("pkcs7")]
    public string? Pkcs7 { get; set; }

    /// <summary>
    /// Signing certificate public key in X.509 (.CER) format.
    /// </summary>
    [Optional]
    [JsonPropertyName("cert")]
    public string? Cert { get; set; }

    /// <summary>
    /// Subject name for this certificate in the format `/CN={domain}`.
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
