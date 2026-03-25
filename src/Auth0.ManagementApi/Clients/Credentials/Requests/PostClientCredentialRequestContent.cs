using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Clients;

[Serializable]
public record PostClientCredentialRequestContent
{
    [JsonPropertyName("credential_type")]
    public required ClientCredentialTypeEnum CredentialType { get; set; }

    /// <summary>
    /// Friendly name for a credential.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Subject Distinguished Name. Mutually exclusive with `pem` property. Applies to `cert_subject_dn` credential type.
    /// </summary>
    [Optional]
    [JsonPropertyName("subject_dn")]
    public string? SubjectDn { get; set; }

    /// <summary>
    /// PEM-formatted public key (SPKI and PKCS1) or X509 certificate. Must be JSON escaped.
    /// </summary>
    [Optional]
    [JsonPropertyName("pem")]
    public string? Pem { get; set; }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
