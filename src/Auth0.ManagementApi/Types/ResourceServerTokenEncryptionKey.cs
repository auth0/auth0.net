using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ResourceServerTokenEncryptionKey : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the encryption key.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("alg")]
    public ResourceServerTokenEncryptionAlgorithmEnum? Alg { get; set; }

    /// <summary>
    /// Key ID.
    /// </summary>
    [Optional]
    [JsonPropertyName("kid")]
    public string? Kid { get; set; }

    /// <summary>
    /// PEM-formatted public key. Must be JSON escaped.
    /// </summary>
    [Optional]
    [JsonPropertyName("pem")]
    public string? Pem { get; set; }

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
