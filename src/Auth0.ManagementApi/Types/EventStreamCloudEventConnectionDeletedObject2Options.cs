using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'samlp' connection
/// </summary>
[Serializable]
public record EventStreamCloudEventConnectionDeletedObject2Options : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("assertion_decryption_settings")]
    public EventStreamCloudEventConnectionDeletedObject2OptionsAssertionDecryptionSettings? AssertionDecryptionSettings { get; set; }

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
    public EventStreamCloudEventConnectionDeletedObject2OptionsDigestAlgorithmEnum? DigestAlgorithm { get; set; }

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
    public EventStreamCloudEventConnectionDeletedObject2OptionsIdpinitiated? Idpinitiated { get; set; }

    /// <summary>
    /// An array of user fields that should not be stored in the Auth0 database (https://auth0.com/docs/security/data-security/denylist)
    /// </summary>
    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    [Optional]
    [JsonPropertyName("protocolBinding")]
    public EventStreamCloudEventConnectionDeletedObject2OptionsProtocolBindingEnum? ProtocolBinding { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public EventStreamCloudEventConnectionDeletedObject2OptionsSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Optional]
    [JsonPropertyName("signatureAlgorithm")]
    public EventStreamCloudEventConnectionDeletedObject2OptionsSignatureAlgorithmEnum? SignatureAlgorithm { get; set; }

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
    public EventStreamCloudEventConnectionDeletedObject2OptionsSubject? Subject { get; set; }

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
    /// When true, enables detailed SAML debugging by issuing 'w' (warning) events in tenant logs containing SAML request/response details. WARNING: Potentially exposes sensitive user information (PII, credentials) and should only be enabled temporarily for debugging purposes.
    /// </summary>
    [Optional]
    [JsonPropertyName("debug")]
    public bool? Debug { get; set; }

    /// <summary>
    /// When true, enables DEFLATE compression for SAML requests sent via HTTP-Redirect binding.
    /// </summary>
    [Optional]
    [JsonPropertyName("deflate")]
    public bool? Deflate { get; set; }

    /// <summary>
    /// The URL where Auth0 will send SAML authentication requests (the Identity Provider's SSO URL). Must be a valid HTTPS URL.
    /// </summary>
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
    public Dictionary<string, object?>? FieldsMap { get; set; }

    /// <summary>
    /// Expected 'iss' (Issuer) claim value for JWT tokens in Global Token Revocation requests from the identity provider. When configured, Auth0 validates the JWT issuer matches this value before processing token revocation. Must be used together with global_token_revocation_jwt_sub.
    /// </summary>
    [Optional]
    [JsonPropertyName("global_token_revocation_jwt_iss")]
    public string? GlobalTokenRevocationJwtIss { get; set; }

    /// <summary>
    /// Expected 'sub' (Subject) claim value for JWT tokens in Global Token Revocation requests from the identity provider. When configured, Auth0 validates the JWT subject matches this value before processing token revocation. Must be used together with global_token_revocation_jwt_iss.
    /// </summary>
    [Optional]
    [JsonPropertyName("global_token_revocation_jwt_sub")]
    public string? GlobalTokenRevocationJwtSub { get; set; }

    /// <summary>
    /// HTTPS URL to the identity provider's SAML metadata document. When provided, Auth0 automatically fetches and parses the metadata to extract signInEndpoint, signOutEndpoint, signingCert, signSAMLRequest, and protocolBinding. Use metadataUrl OR metadataXml, not both.
    /// </summary>
    [Optional]
    [JsonPropertyName("metadataUrl")]
    public string? MetadataUrl { get; set; }

    /// <summary>
    /// The URL where Auth0 will send SAML authentication requests (the Identity Provider's SSO URL). Must be a valid HTTPS URL.
    /// </summary>
    [Optional]
    [JsonPropertyName("recipientUrl")]
    public string? RecipientUrl { get; set; }

    /// <summary>
    /// Custom XML template for SAML authentication requests. Supports variable substitution using @@variableName@@ syntax. When not provided, uses default SAML AuthnRequest template. See https://auth0.com/docs/authenticate/protocols/saml/saml-sso-integrations/configure-auth0-saml-service-provider#customize-the-request-template
    /// </summary>
    [Optional]
    [JsonPropertyName("requestTemplate")]
    public string? RequestTemplate { get; set; }

    /// <summary>
    /// Identity provider's SAML SingleLogoutService endpoint URL where Auth0 sends logout requests for federated sign-out. When not provided, defaults to signInEndpoint. Only used if disableSignout is false.
    /// </summary>
    [Optional]
    [JsonPropertyName("signOutEndpoint")]
    public string? SignOutEndpoint { get; set; }

    /// <summary>
    /// Custom SAML assertion attribute to use as the unique user identifier. When provided, this attribute is prepended to the default user_id mapping list with highest priority. Accepts a string (single SAML attribute name).
    /// </summary>
    [Optional]
    [JsonPropertyName("user_id_attribute")]
    public string? UserIdAttribute { get; set; }

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
