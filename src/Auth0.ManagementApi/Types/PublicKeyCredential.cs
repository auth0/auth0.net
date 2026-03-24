using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record PublicKeyCredential : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("credential_type")]
    public required PublicKeyCredentialTypeEnum CredentialType { get; set; }

    /// <summary>
    /// Friendly name for a credential.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// PEM-formatted public key (SPKI and PKCS1) or X509 certificate. Must be JSON escaped.
    /// </summary>
    [JsonPropertyName("pem")]
    public required string Pem { get; set; }

    [Optional]
    [JsonPropertyName("alg")]
    public PublicKeyCredentialAlgorithmEnum? Alg { get; set; }

    /// <summary>
    /// Parse expiry from x509 certificate. If true, attempts to parse the expiry date from the provided PEM. Applies to `public_key` credential type.
    /// </summary>
    [Optional]
    [JsonPropertyName("parse_expiry_from_cert")]
    public bool? ParseExpiryFromCert { get; set; }

    /// <summary>
    /// The ISO 8601 formatted date representing the expiration of the credential. If not specified (not recommended), the credential never expires. Applies to `public_key` credential type.
    /// </summary>
    [Optional]
    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// Optional kid (Key ID), used to uniquely identify the credential. If not specified, a kid value will be auto-generated. The kid header parameter in JWTs sent by your client should match this value. Valid format is [0-9a-zA-Z-_]{10,64}
    /// </summary>
    [Optional]
    [JsonPropertyName("kid")]
    public string? Kid { get; set; }

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
