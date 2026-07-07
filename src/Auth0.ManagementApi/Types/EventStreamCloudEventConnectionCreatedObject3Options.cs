using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'pingfederate' connection
/// </summary>
[Serializable]
public record EventStreamCloudEventConnectionCreatedObject3Options : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("assertion_decryption_settings")]
    public EventStreamCloudEventConnectionCreatedObject3OptionsAssertionDecryptionSettings? AssertionDecryptionSettings { get; set; }

    /// <summary>
    /// X.509 signing certificate from the identity provider in .der format. Used to validate signatures in SAML Responses and Assertions. This is an alternative to signingCert and is kept for backward compatibility. Prefer using signingCert instead.
    /// </summary>
    [Optional]
    [JsonPropertyName("cert")]
    public string? Cert { get; set; }

    /// <summary>
    /// Timestamp of the last certificate expiring soon notification.
    /// </summary>
    [Optional]
    [JsonPropertyName("cert_rollover_notification")]
    public DateTime? CertRolloverNotification { get; set; }

    [Optional]
    [JsonPropertyName("digestAlgorithm")]
    public EventStreamCloudEventConnectionCreatedObject3OptionsDigestAlgorithmEnum? DigestAlgorithm { get; set; }

    /// <summary>
    /// Domain aliases for the connection
    /// </summary>
    [Optional]
    [JsonPropertyName("domain_aliases")]
    public IEnumerable<string>? DomainAliases { get; set; }

    /// <summary>
    /// The entity identifier (Issuer) for the SAML Service Provider. When not provided, defaults to 'urn:auth0:{tenant}:{connection}'. This value is included in SAML AuthnRequest messages sent to the identity provider.
    /// </summary>
    [Optional]
    [JsonPropertyName("entityId")]
    public string? EntityId { get; set; }

    /// <summary>
    /// ISO 8601 formatted datetime indicating when the identity provider's signing certificate expires.
    /// </summary>
    [Optional]
    [JsonPropertyName("expires")]
    public DateTime? Expires { get; set; }

    /// <summary>
    /// URL for the connection icon displayed in Auth0 login pages. Accepts HTTPS URLs. Used for visual branding in authentication flows.
    /// </summary>
    [Optional]
    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    [Optional]
    [JsonPropertyName("idpinitiated")]
    public EventStreamCloudEventConnectionCreatedObject3OptionsIdpinitiated? Idpinitiated { get; set; }

    /// <summary>
    /// An array of user fields that should not be stored in the Auth0 database (https://auth0.com/docs/security/data-security/denylist)
    /// </summary>
    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    [Optional]
    [JsonPropertyName("protocolBinding")]
    public EventStreamCloudEventConnectionCreatedObject3OptionsProtocolBindingEnum? ProtocolBinding { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public EventStreamCloudEventConnectionCreatedObject3OptionsSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Optional]
    [JsonPropertyName("signatureAlgorithm")]
    public EventStreamCloudEventConnectionCreatedObject3OptionsSignatureAlgorithmEnum? SignatureAlgorithm { get; set; }

    /// <summary>
    /// Identity provider's SAML SingleSignOnService endpoint URL where Auth0 sends SAML authentication requests. This is the primary login URL for the SAML connection. Required unless using metadataUrl or metadataXml.
    /// </summary>
    [Optional]
    [JsonPropertyName("signInEndpoint")]
    public string? SignInEndpoint { get; set; }

    /// <summary>
    /// Base64-encoded X.509 certificate from the identity provider used to validate signatures in SAML responses and assertions. The certificate is decoded and used for cryptographic signature verification.
    /// </summary>
    [Optional]
    [JsonPropertyName("signingCert")]
    public string? SigningCert { get; set; }

    /// <summary>
    /// When true, Auth0 signs SAML authentication requests using the connection's signing key. The signature includes the request's digest and is validated by the identity provider. Defaults to false (unsigned requests).
    /// </summary>
    [Optional]
    [JsonPropertyName("signSAMLRequest")]
    public bool? SignSamlRequest { get; set; }

    [Optional]
    [JsonPropertyName("subject")]
    public EventStreamCloudEventConnectionCreatedObject3OptionsSubject? Subject { get; set; }

    /// <summary>
    /// For SAML connections, the tenant domain used to construct the login endpoint URL. Can be a string for single-tenant or an array of strings for multi-tenant validation.
    /// </summary>
    [Optional]
    [JsonPropertyName("tenant_domain")]
    public string? TenantDomain { get; set; }

    /// <summary>
    /// SHA-1 thumbprints (fingerprints) of the identity provider's signing certificates. Automatically computed from signingCert during connection creation. Each thumbprint must be a 40-character hexadecimal string.
    /// </summary>
    [Optional]
    [JsonPropertyName("thumbprints")]
    public IEnumerable<string>? Thumbprints { get; set; }

    [Optional]
    [JsonPropertyName("upstream_params")]
    public Dictionary<string, object?>? UpstreamParams { get; set; }

    /// <summary>
    /// URL provided by PingFederate which returns information used for creating the connection
    /// </summary>
    [JsonPropertyName("pingFederateBaseUrl")]
    public required string PingFederateBaseUrl { get; set; }

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
