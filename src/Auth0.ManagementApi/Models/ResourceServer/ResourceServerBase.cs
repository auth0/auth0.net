using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Base class for resource server payloads
/// </summary>
public class ResourceServerBase
{
    /// <summary>
    /// The name of the resource server
    /// </summary>
    /// <remarks>
    /// Must contain at least one character. Does not allow '&lt;' or '&gt;'"
    /// </remarks>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// The available scopes for the resource server
    /// </summary>
    [JsonProperty("scopes")]
    public List<ResourceServerScope> Scopes { get; set; }

    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.SigningAlgorithm"/>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("signing_alg")]
    public SigningAlgorithm? SigningAlgorithm { get; set; }

    /// <summary>
    /// The secret used to sign tokens when using symmetric algorithms
    /// </summary>
    [JsonProperty("signing_secret")]
    public string SigningSecret { get; set; }

    /// <summary>
    /// The amount of time (in seconds) that the token will be valid after being issued
    /// </summary>
    [JsonProperty("token_lifetime")]
    public int? TokenLifetime { get; set; }

    /// <summary>
    /// The amount of time (in seconds) that the token will be valid after being issued from browser based flows.
    /// Value cannot be larger than <see cref="TokenLifetime" />
    /// </summary>
    [JsonProperty("token_lifetime_for_web")]
    public int? TokenLifetimeForWeb { get; set; }

    /// <summary>
    /// Allows issuance of refresh tokens for this entity
    /// </summary>
    [JsonProperty("allow_offline_access")]
    public bool? AllowOfflineAccess { get; set; }

    /// <summary>
    /// Flag this entity as capable of skipping consent
    /// </summary>
    [JsonProperty("skip_consent_for_verifiable_first_party_clients")]
    public bool? SkipConsentForVerifiableFirstPartyClients { get; set; }

    /// <summary>
    /// A uri from which to retrieve JWKs for this resource server used for verifying the JWT sent to Auth0 for token introspection.
    /// </summary>
    [JsonProperty("verificationLocation")]
    public string VerificationLocation { get; set; }

    /// <summary>
    /// The dialect for the access token.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("token_dialect")]
    public TokenDialect? TokenDialect { get; set; }

    /// <summary>
    /// Enables the enforcement of the authorization policies.
    /// </summary>
    [JsonProperty("enforce_policies")]
    public bool? EnforcePolicies { get; set; }
        
    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.ConsentPolicy"/>
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("consent_policy")]
    public ConsentPolicy? ConsentPolicy { get; set; }
        
    /// <summary>
    /// <inheritdoc cref="ResourceServerAuthorizationDetail"/>
    /// </summary>
    [JsonProperty("authorization_details")]
    public IList<ResourceServerAuthorizationDetail> AuthorizationDetails { get; set; }
        
    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.TokenEncryption"/>
    /// </summary>
    [JsonProperty("token_encryption")]
    public TokenEncryption TokenEncryption { get; set; }

    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.ProofOfPossession"/>
    /// </summary>
    [JsonProperty("proof_of_possession")]
    public ProofOfPossession ProofOfPossession { get; set; }
    
    /// <summary>
    /// <inheritdoc cref="Auth0.ManagementApi.Models.SubjectTypeAuthorization"/>
    /// </summary>
    [JsonProperty("subject_type_authorization")]
    public SubjectTypeAuthorization? SubjectTypeAuthorization { get; set; }
}