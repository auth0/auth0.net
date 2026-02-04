using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record CreateEncryptionKeyPublicWrappingResponseContent
    : IJsonOnDeserialized,
        IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Public wrapping key in PEM format
    /// </summary>
    [JsonPropertyName("public_key")]
    public required string PublicKey { get; set; }

    [JsonPropertyName("algorithm")]
    public string Algorithm { get; set; } = "CKM_RSA_AES_KEY_WRAP";

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
