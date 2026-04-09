using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Private Key JWT authentication configuration
/// </summary>
[Serializable]
public record CimdMappedClientAuthenticationMethodsPrivateKeyJwt
    : IJsonOnDeserialized,
        IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Credentials derived from the JWKS document
    /// </summary>
    [JsonPropertyName("credentials")]
    public IEnumerable<CimdMappedPrivateKeyJwtCredential> Credentials { get; set; } =
        new List<CimdMappedPrivateKeyJwtCredential>();

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
