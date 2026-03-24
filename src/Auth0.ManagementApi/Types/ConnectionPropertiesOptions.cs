using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// The connection's options (depend on the connection strategy)
/// </summary>
[Serializable]
public record ConnectionPropertiesOptions : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Nullable, Optional]
    [JsonPropertyName("validation")]
    public Optional<ConnectionValidationOptions?> Validation { get; set; }

    /// <summary>
    /// An array of user fields that should not be stored in the Auth0 database (https://auth0.com/docs/security/data-security/denylist)
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public Optional<IEnumerable<string>?> NonPersistentAttrs { get; set; }

    /// <summary>
    /// Order of precedence for attribute types. If the property is not specified, the default precedence of attributes will be used.
    /// </summary>
    [Optional]
    [JsonPropertyName("precedence")]
    public IEnumerable<ConnectionIdentifierPrecedenceEnum>? Precedence { get; set; }

    [Optional]
    [JsonPropertyName("attributes")]
    public ConnectionAttributes? Attributes { get; set; }

    /// <summary>
    /// Set to true to inject context into custom DB scripts (warning: cannot be disabled once enabled)
    /// </summary>
    [Optional]
    [JsonPropertyName("enable_script_context")]
    public bool? EnableScriptContext { get; set; }

    /// <summary>
    /// Set to true to use a legacy user store
    /// </summary>
    [Optional]
    [JsonPropertyName("enabledDatabaseCustomization")]
    public bool? EnabledDatabaseCustomization { get; set; }

    /// <summary>
    /// Enable this if you have a legacy user store and you want to gradually migrate those users to the Auth0 user store
    /// </summary>
    [Optional]
    [JsonPropertyName("import_mode")]
    public bool? ImportMode { get; set; }

    /// <summary>
    /// Stores encrypted string only configurations for connections
    /// </summary>
    [Nullable, Optional]
    [JsonPropertyName("configuration")]
    public Optional<Dictionary<string, string?>?> Configuration { get; set; }

    [Optional]
    [JsonPropertyName("customScripts")]
    public ConnectionCustomScripts? CustomScripts { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("authentication_methods")]
    public Optional<ConnectionAuthenticationMethods?> AuthenticationMethods { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("passkey_options")]
    public Optional<ConnectionPasskeyOptions?> PasskeyOptions { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("passwordPolicy")]
    public Optional<ConnectionPasswordPolicyEnum?> PasswordPolicy { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("password_complexity_options")]
    public Optional<ConnectionPasswordComplexityOptions?> PasswordComplexityOptions { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("password_history")]
    public Optional<ConnectionPasswordHistoryOptions?> PasswordHistory { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("password_no_personal_info")]
    public Optional<ConnectionPasswordNoPersonalInfoOptions?> PasswordNoPersonalInfo { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("password_dictionary")]
    public Optional<ConnectionPasswordDictionaryOptions?> PasswordDictionary { get; set; }

    [Optional]
    [JsonPropertyName("api_enable_users")]
    public bool? ApiEnableUsers { get; set; }

    [Optional]
    [JsonPropertyName("basic_profile")]
    public bool? BasicProfile { get; set; }

    [Optional]
    [JsonPropertyName("ext_admin")]
    public bool? ExtAdmin { get; set; }

    [Optional]
    [JsonPropertyName("ext_is_suspended")]
    public bool? ExtIsSuspended { get; set; }

    [Optional]
    [JsonPropertyName("ext_agreed_terms")]
    public bool? ExtAgreedTerms { get; set; }

    [Optional]
    [JsonPropertyName("ext_groups")]
    public bool? ExtGroups { get; set; }

    [Optional]
    [JsonPropertyName("ext_assigned_plans")]
    public bool? ExtAssignedPlans { get; set; }

    [Optional]
    [JsonPropertyName("ext_profile")]
    public bool? ExtProfile { get; set; }

    [Optional]
    [JsonPropertyName("disable_self_service_change_password")]
    public bool? DisableSelfServiceChangePassword { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("gateway_authentication")]
    public Optional<ConnectionGatewayAuthentication?> GatewayAuthentication { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("federated_connections_access_tokens")]
    public Optional<ConnectionFederatedConnectionsAccessTokens?> FederatedConnectionsAccessTokens { get; set; }

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
