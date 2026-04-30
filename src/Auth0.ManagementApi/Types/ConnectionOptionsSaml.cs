using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'samlp' connection
/// </summary>
[Serializable]
public record ConnectionOptionsSaml : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("debug")]
    public bool? Debug { get; set; }

    [Optional]
    [JsonPropertyName("deflate")]
    public bool? Deflate { get; set; }

    [Optional]
    [JsonPropertyName("destinationUrl")]
    public string? DestinationUrl { get; set; }

    /// <summary>
    /// When true, disables sending SAML logout requests (SingleLogoutService) to the identity provider during user sign-out. The user will be logged out of Auth0 but will remain logged into the identity provider. Defaults to false (federated logout enabled).
    /// </summary>
    [Optional]
    [JsonPropertyName("disableSignout")]
    public bool? DisableSignout { get; set; }

    [Optional]
    [JsonPropertyName("fieldsMap")]
    public Dictionary<string, ConnectionFieldsMapSamlValue>? FieldsMap { get; set; }

    [Optional]
    [JsonPropertyName("global_token_revocation_jwt_iss")]
    public string? GlobalTokenRevocationJwtIss { get; set; }

    [Optional]
    [JsonPropertyName("global_token_revocation_jwt_sub")]
    public string? GlobalTokenRevocationJwtSub { get; set; }

    [Optional]
    [JsonPropertyName("metadataUrl")]
    public string? MetadataUrl { get; set; }

    [Optional]
    [JsonPropertyName("metadataXml")]
    public string? MetadataXml { get; set; }

    [Optional]
    [JsonPropertyName("recipientUrl")]
    public string? RecipientUrl { get; set; }

    [Optional]
    [JsonPropertyName("requestTemplate")]
    public string? RequestTemplate { get; set; }

    [Optional]
    [JsonPropertyName("signingCert")]
    public string? SigningCert { get; set; }

    [Optional]
    [JsonPropertyName("signing_key")]
    public ConnectionSigningKeySaml? SigningKey { get; set; }

    [Optional]
    [JsonPropertyName("signOutEndpoint")]
    public string? SignOutEndpoint { get; set; }

    [Optional]
    [JsonPropertyName("user_id_attribute")]
    public string? UserIdAttribute { get; set; }

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
