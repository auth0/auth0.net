using System.Collections.Specialized;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// The connection's options.
/// </summary>
public class ConnectionOptions
{
    /// <inheritdoc cref="ConnectionOptionsValidation"/> 
    [JsonProperty("validation")]
    public ConnectionOptionsValidation Validation { get; set; }
        
    /// <summary>
    /// An array of user fields that should not be stored in the Auth0 database 
    /// <a href="https://auth0.com/docs/security/data-security/denylist">https://auth0.com/docs/security/data-security/denylist</a>
    /// </summary>
    [JsonProperty("non_persistent_attrs")]
    public string[] NonPersistentAttributes { get; set; }
        
    /// <summary>
    /// Order of precedence for attribute types. If the property is not specified,
    /// the default precedence of attributes will be used.
    /// </summary>
    [JsonProperty("precedence", ItemConverterType = typeof(StringEnumConverter))]
    public ConnectionOptionsPrecedence[] Precedence { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsAttributes"/> 
    [JsonProperty("attributes")]
    public ConnectionOptionsAttributes Attributes { get; set; }
        
    [JsonProperty("enable_script_context")]
    public bool? EnableScriptContext { get; set; }
        
    /// <summary>
    /// Set to true to use a legacy user store
    /// </summary>
    [JsonProperty("enabledDatabaseCustomization")]
    public bool? EnableDatabaseCustomization { get; set; }
        
    /// <summary>
    /// Enable this if you have a legacy user store and you want to gradually migrate
    /// those users to the Auth0 user store
    /// </summary>
    [JsonProperty("import_mode")]
    public bool? ImportMode { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsCustomScripts"/>
    [JsonProperty("customScripts")]
    public ConnectionOptionsCustomScripts CustomScripts { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsAuthenticationMethods"/>
    [JsonProperty("authentication_methods")]
    public ConnectionOptionsAuthenticationMethods AuthenticationMethods { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsPasskeyOptions"/>
    [JsonProperty("passkey_options")]
    public ConnectionOptionsPasskeyOptions PasskeyOptions { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsPasswordPolicy"/>
    [JsonProperty("passwordPolicy")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ConnectionOptionsPasswordPolicy? PasswordPolicy { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsPasswordComplexityOptions"/>
    [JsonProperty("password_complexity_options")]
    public ConnectionOptionsPasswordComplexityOptions PasswordComplexityOptions { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsPasswordHistory"/>
    [JsonProperty("password_history")]
    public ConnectionOptionsPasswordHistory PasswordHistory { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsPasswordNoPersonalInfo"/>
    [JsonProperty("password_no_personal_info")]
    public ConnectionOptionsPasswordNoPersonalInfo PasswordNoPersonalInfo { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsPasswordNoPersonalInfo"/>
    [JsonProperty("password_dictionary")]
    public ConnectionOptionsPasswordDictionary PasswordDictionary { get; set; }
        
    [JsonProperty("api_enable_users")]
    public bool? ApiEnableUsers { get; set; }
        
    [JsonProperty("basic_profile")]
    public bool? BasicProfile { get; set; }
        
    [JsonProperty("ext_admin")]
    public bool? ExtAdmin { get; set; }
        
    [JsonProperty("ext_is_suspended")]
    public bool? ExtIsSuspended { get; set; }
        
    [JsonProperty("ext_agreed_terms")]
    public bool? ExtAgreedTerms { get; set; }
        
    [JsonProperty("ext_groups")]
    public bool? ExtGroups { get; set; }
        
    [JsonProperty("ext_assigned_plans")]
    public bool? ExtAssignedPlans { get; set; }
        
    [JsonProperty("ext_profile")]
    public bool? ExtProfile { get; set; }
        
    [JsonProperty("disable_self_service_change_password")]
    public bool? DisableSelfServiceChangePassword { get; set; }
        
    /// <summary>
    /// Options for adding parameters in the request to the upstream IdP
    /// </summary>
    [JsonProperty("upstream_params")]
    public dynamic UpstreamParams { get; set; }
        
    /// <inheritdoc cref="Auth0.ManagementApi.Models.Connections.SetUserRootAttributes"/>
    [JsonProperty("set_user_root_attributes")]
    [JsonConverter(typeof(StringEnumConverter))]
    public SetUserRootAttributes? SetUserRootAttributes { get; set; }
        
    /// <inheritdoc cref="Auth0.ManagementApi.Models.Connections.SetUserRootAttributes"/>
    [JsonProperty("gateway_authentication")]
    public GatewayAuthentication GatewayAuthentication { get; set; }
}