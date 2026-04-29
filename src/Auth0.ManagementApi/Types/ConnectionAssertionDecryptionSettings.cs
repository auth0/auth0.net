using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Settings for SAML assertion decryption.
/// </summary>
[Serializable]
public record ConnectionAssertionDecryptionSettings : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("algorithm_profile")]
    public required ConnectionAssertionDecryptionAlgorithmProfileEnum AlgorithmProfile { get; set; }

    /// <summary>
    /// A list of insecure algorithms to allow for SAML assertion decryption.
    /// </summary>
    [Optional]
    [JsonPropertyName("algorithm_exceptions")]
    public IEnumerable<string>? AlgorithmExceptions { get; set; }

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
