using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models;

/// <summary>
/// Represents session transfer configuration for a client.
/// </summary>
public class SessionTransfer
{
    /// <summary>
    /// Indicates if the client can create session transfer tokens.
    /// </summary>
    [JsonProperty("can_create_session_transfer_token")]
    public bool? CanCreateSessionTransferToken { get; set; }

    /// <summary>
    /// Allowed authentication methods for session transfer.
    /// </summary>
    [JsonProperty("allowed_authentication_methods", ItemConverterType = typeof(StringEnumConverter))]
    public SessionTransferAuthenticationMethod[]? AllowedAuthenticationMethods { get; set; }

    /// <summary>
    /// Enforce device binding method.
    /// </summary>
    [JsonProperty("enforce_device_binding")]
    [JsonConverter(typeof(StringEnumConverter))]
    public SessionTransferDeviceBinding? EnforceDeviceBinding { get; set; }

    /// <summary>
    /// Whether refresh tokens are allowed in session transfer.
    /// </summary>
    [JsonProperty("allow_refresh_token")]
    public bool? AllowRefreshToken { get; set; }

    /// <summary>
    /// Whether to enforce cascade revocation.
    /// </summary>
    [JsonProperty("enforce_cascade_revocation")]
    public bool? EnforceCascadeRevocation { get; set; }

    /// <summary>
    /// Whether to enforce online refresh tokens.
    /// </summary>
    [JsonProperty("enforce_online_refresh_tokens")]
    public bool? EnforceOnlineRefreshTokens { get; set; }
}
