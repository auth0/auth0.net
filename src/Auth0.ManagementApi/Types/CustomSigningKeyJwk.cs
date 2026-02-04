using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// JWK representing a custom public signing key.
/// </summary>
[Serializable]
public record CustomSigningKeyJwk : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("kty")]
    public required CustomSigningKeyTypeEnum Kty { get; set; }

    /// <summary>
    /// Key identifier
    /// </summary>
    [Optional]
    [JsonPropertyName("kid")]
    public string? Kid { get; set; }

    [Optional]
    [JsonPropertyName("use")]
    public string? Use { get; set; }

    /// <summary>
    /// Key operations
    /// </summary>
    [Optional]
    [JsonPropertyName("key_ops")]
    public IEnumerable<string>? KeyOps { get; set; }

    [Optional]
    [JsonPropertyName("alg")]
    public CustomSigningKeyAlgorithmEnum? Alg { get; set; }

    /// <summary>
    /// Key modulus
    /// </summary>
    [Optional]
    [JsonPropertyName("n")]
    public string? N { get; set; }

    /// <summary>
    /// Key exponent
    /// </summary>
    [Optional]
    [JsonPropertyName("e")]
    public string? E { get; set; }

    [Optional]
    [JsonPropertyName("crv")]
    public CustomSigningKeyCurveEnum? Crv { get; set; }

    /// <summary>
    /// X coordinate
    /// </summary>
    [Optional]
    [JsonPropertyName("x")]
    public string? X { get; set; }

    /// <summary>
    /// Y coordinate
    /// </summary>
    [Optional]
    [JsonPropertyName("y")]
    public string? Y { get; set; }

    /// <summary>
    /// X.509 URL
    /// </summary>
    [Optional]
    [JsonPropertyName("x5u")]
    public string? X5U { get; set; }

    /// <summary>
    /// X.509 certificate chain
    /// </summary>
    [Optional]
    [JsonPropertyName("x5c")]
    public IEnumerable<string>? X5C { get; set; }

    /// <summary>
    /// X.509 certificate SHA-1 thumbprint
    /// </summary>
    [Optional]
    [JsonPropertyName("x5t")]
    public string? X5T { get; set; }

    /// <summary>
    /// X.509 certificate SHA-256 thumbprint
    /// </summary>
    [Optional]
    [JsonPropertyName("x5t#S256")]
    public string? X5TS256 { get; set; }

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
