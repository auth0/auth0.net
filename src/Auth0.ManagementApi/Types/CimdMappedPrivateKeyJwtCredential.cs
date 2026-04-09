using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record CimdMappedPrivateKeyJwtCredential : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Type of credential (e.g., public_key)
    /// </summary>
    [JsonPropertyName("credential_type")]
    public required string CredentialType { get; set; }

    /// <summary>
    /// Key identifier from JWKS or calculated thumbprint
    /// </summary>
    [JsonPropertyName("kid")]
    public required string Kid { get; set; }

    /// <summary>
    /// Algorithm (e.g., RS256, RS384, PS256)
    /// </summary>
    [JsonPropertyName("alg")]
    public required string Alg { get; set; }

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
