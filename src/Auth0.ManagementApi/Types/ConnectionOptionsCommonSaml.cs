using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Common options for SAML-based enterprise connections (shared by samlp and pingfederate).
/// </summary>
[Serializable]
public record ConnectionOptionsCommonSaml : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("assertion_decryption_settings")]
    public ConnectionAssertionDecryptionSettings? AssertionDecryptionSettings { get; set; }

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
