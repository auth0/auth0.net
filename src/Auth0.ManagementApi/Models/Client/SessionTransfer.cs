using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Native to Web SSO configuration.
/// </summary>
public class SessionTransfer
{
    /// <summary>
    /// Indicates whether an app can issue a session_token through Token Exchange.
    /// If set to 'false', the app will not be able to issue a session_token.
    /// </summary>
    [JsonProperty("can_create_session_transfer_token")]
    public bool? CanCreateSessionTransferToken { get; set; }
    
    /// <summary>
    /// Indicates whether an app can create a session from a session_token received via indicated methods.
    /// </summary>
    [JsonProperty("allowed_authentication_methods")]
    public string[]? AllowedAuthenticationMethods { get; set; }
    
    /// <summary>
    /// Indicates whether device binding security should be enforced for the app.
    /// If set to 'ip', the app will enforce device binding by IP, meaning that consumption of session_token must be
    /// done from the same IP of the issuer.
    /// Likewise, if set to 'asn', device binding is enforced by ASN, meaning consumption of session_token must be
    /// done from the same ASN as the issuer.
    /// If set to 'null', device binding is not enforced.
    /// </summary>
    /// <remarks>Possible values: [ip, asn, none]</remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("enforce_device_binding")]
    public DeviceBindingType? EnforceDeviceBinding { get; set; }
    
    /// <summary>
    /// Indicates whether Refresh Tokens are allowed to be issued when authenticating with a session_transfer_token.
    /// </summary>
    [JsonProperty("allow_refresh_token")]
    public bool? AllowRefreshToken { get; set; }
    
    /// <summary>
    /// Indicates whether Refresh Tokens created during a native-to-web session are tied to that session's lifetime.
    /// This determines if such refresh tokens should be automatically revoked when their corresponding sessions are.
    /// </summary>
    [JsonProperty("enforce_online_refresh_tokens")]
    public bool? EnforceOnlineRefreshTokens { get; set; }
    
    /// <summary>
    /// Indicates whether revoking the parent Refresh Token that initiated a Native to Web flow and was used to issue
    /// a Session Transfer Token should trigger a cascade revocation affecting its dependent child entities.
    /// </summary>
    [JsonProperty("enforce_cascade_revocation")]
    public bool? EnforceCascadeRevocation { get; set; }
}