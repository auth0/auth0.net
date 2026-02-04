using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'auth0' connection
/// </summary>
[Serializable]
public record ConnectionOptionsAuth0 : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("attributes")]
    public ConnectionAttributes? Attributes { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("authentication_methods")]
    public Optional<ConnectionAuthenticationMethods?> AuthenticationMethods { get; set; }

    [Optional]
    [JsonPropertyName("brute_force_protection")]
    public bool? BruteForceProtection { get; set; }

    [Optional]
    [JsonPropertyName("configuration")]
    public Dictionary<string, string>? Configuration { get; set; }

    [Optional]
    [JsonPropertyName("customScripts")]
    public ConnectionCustomScripts? CustomScripts { get; set; }

    [Optional]
    [JsonPropertyName("disable_self_service_change_password")]
    public bool? DisableSelfServiceChangePassword { get; set; }

    [Optional]
    [JsonPropertyName("disable_signup")]
    public bool? DisableSignup { get; set; }

    [Optional]
    [JsonPropertyName("enable_script_context")]
    public bool? EnableScriptContext { get; set; }

    [Optional]
    [JsonPropertyName("enabledDatabaseCustomization")]
    public bool? EnabledDatabaseCustomization { get; set; }

    [Optional]
    [JsonPropertyName("import_mode")]
    public bool? ImportMode { get; set; }

    [Optional]
    [JsonPropertyName("mfa")]
    public ConnectionMfa? Mfa { get; set; }

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
    [JsonPropertyName("password_dictionary")]
    public Optional<ConnectionPasswordDictionaryOptions?> PasswordDictionary { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("password_history")]
    public Optional<ConnectionPasswordHistoryOptions?> PasswordHistory { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("password_no_personal_info")]
    public Optional<ConnectionPasswordNoPersonalInfoOptions?> PasswordNoPersonalInfo { get; set; }

    [Optional]
    [JsonPropertyName("precedence")]
    public IEnumerable<ConnectionIdentifierPrecedenceEnum>? Precedence { get; set; }

    [Optional]
    [JsonPropertyName("realm_fallback")]
    public bool? RealmFallback { get; set; }

    [Optional]
    [JsonPropertyName("requires_username")]
    public bool? RequiresUsername { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("validation")]
    public Optional<ConnectionValidationOptions?> Validation { get; set; }

    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

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
