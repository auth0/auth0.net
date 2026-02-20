using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'pingfederate' connection
/// </summary>
[Serializable]
public record ConnectionOptionsPingFederate : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [JsonPropertyName("pingFederateBaseUrl")]
    public required string PingFederateBaseUrl { get; set; }

    [Optional]
    [JsonPropertyName("signingCert")]
    public string? SigningCert { get; set; }

    [Optional]
    [JsonPropertyName("cert")]
    public string? Cert { get; set; }

    [Optional]
    [JsonPropertyName("decryptionKey")]
    public ConnectionDecryptionKeySaml? DecryptionKey { get; set; }

    [Optional]
    [JsonPropertyName("digestAlgorithm")]
    public ConnectionDigestAlgorithmEnumSaml? DigestAlgorithm { get; set; }

    [Optional]
    [JsonPropertyName("domain_aliases")]
    public IEnumerable<string>? DomainAliases { get; set; }

    [Optional]
    [JsonPropertyName("entityId")]
    public string? EntityId { get; set; }

    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    [Optional]
    [JsonPropertyName("idpinitiated")]
    public ConnectionOptionsIdpinitiatedSaml? Idpinitiated { get; set; }

    [Optional]
    [JsonPropertyName("protocolBinding")]
    public ConnectionProtocolBindingEnumSaml? ProtocolBinding { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Optional]
    [JsonPropertyName("signInEndpoint")]
    public string? SignInEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("signSAMLRequest")]
    public bool? SignSamlRequest { get; set; }

    [Optional]
    [JsonPropertyName("signatureAlgorithm")]
    public ConnectionSignatureAlgorithmEnumSaml? SignatureAlgorithm { get; set; }

    [Optional]
    [JsonPropertyName("tenant_domain")]
    public string? TenantDomain { get; set; }

    [Optional]
    [JsonPropertyName("thumbprints")]
    public IEnumerable<string>? Thumbprints { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

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
