using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// Options for the passkey authentication method
/// </summary>
public class ConnectionOptionsPasskeyOptions
{
    /// <inheritdoc cref="Auth0.ManagementApi.Models.Connections.ChallengeUi"/> 
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("challenge_ui")]
    public ChallengeUi ChallengeUi { get; set; }
        
    /// <summary>
    /// Enables or disables progressive enrollment of passkeys for the connection.
    /// </summary>
    [JsonProperty("progressive_enrollment_enabled")]
    public bool? ProgressiveEnrollmentEnabled {get; set;}
        
    /// <summary>
    /// Enables or disables enrollment prompt for local passkey when user authenticates
    /// using a cross-device passkey for the connection.
    /// </summary>
    [JsonProperty("local_enrollment_enabled")]
    public bool? LocalEnrollmentEnabled { get; set; }
}

/// <summary>
/// Controls the UI used to challenge the user for their passkey.
/// </summary>
public enum ChallengeUi
{
    [EnumMember(Value = "both")]
    Both,
        
    [EnumMember(Value = "autofill")]
    AutoFill,
        
    [EnumMember(Value = "button")]
    Button
}