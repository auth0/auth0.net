using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record RotateConnectionKeysRequestContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether to rotate the signing key (default) or the encryption key for the connection.
    /// </summary>
    [Optional]
    [JsonPropertyName("key_use")]
    public ConnectionKeyUseEnum? KeyUse { get; set; }

    [Optional]
    [JsonPropertyName("signing_alg")]
    public RotateConnectionKeysSigningAlgEnum? SigningAlg { get; set; }

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
