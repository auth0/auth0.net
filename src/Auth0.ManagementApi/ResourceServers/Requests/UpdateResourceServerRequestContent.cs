using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateResourceServerRequestContent
{
    /// <summary>
    /// Friendly name for this resource server. Can not contain `&lt;` or `&gt;` characters.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// List of permissions (scopes) that this API uses.
    /// </summary>
    [Optional]
    [JsonPropertyName("scopes")]
    public IEnumerable<ResourceServerScope>? Scopes { get; set; }

    [Optional]
    [JsonPropertyName("signing_alg")]
    public SigningAlgorithmEnum? SigningAlg { get; set; }

    /// <summary>
    /// Secret used to sign tokens when using symmetric algorithms (HS256).
    /// </summary>
    [Optional]
    [JsonPropertyName("signing_secret")]
    public string? SigningSecret { get; set; }

    /// <summary>
    /// Whether to skip user consent for applications flagged as first party (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("skip_consent_for_verifiable_first_party_clients")]
    public bool? SkipConsentForVerifiableFirstPartyClients { get; set; }

    /// <summary>
    /// Whether refresh tokens can be issued for this API (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_offline_access")]
    public bool? AllowOfflineAccess { get; set; }

    /// <summary>
    /// Expiration value (in seconds) for access tokens issued for this API from the token endpoint.
    /// </summary>
    [Optional]
    [JsonPropertyName("token_lifetime")]
    public int? TokenLifetime { get; set; }

    [Optional]
    [JsonPropertyName("token_dialect")]
    public ResourceServerTokenDialectSchemaEnum? TokenDialect { get; set; }

    /// <summary>
    /// Whether authorization policies are enforced (true) or not enforced (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("enforce_policies")]
    public bool? EnforcePolicies { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("token_encryption")]
    public Optional<ResourceServerTokenEncryption?> TokenEncryption { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("consent_policy")]
    public Optional<ResourceServerConsentPolicyEnum?> ConsentPolicy { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("authorization_details")]
    public Optional<IEnumerable<object>?> AuthorizationDetails { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("proof_of_possession")]
    public Optional<ResourceServerProofOfPossession?> ProofOfPossession { get; set; }

    [Optional]
    [JsonPropertyName("subject_type_authorization")]
    public ResourceServerSubjectTypeAuthorization? SubjectTypeAuthorization { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
