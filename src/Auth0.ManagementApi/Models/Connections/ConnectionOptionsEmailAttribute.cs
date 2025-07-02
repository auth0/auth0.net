using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// Configuration for the email attribute for users.
/// </summary>
public class ConnectionOptionsEmailAttribute : ConnectionOptionsAttributeBase
{
    /// <summary>
    /// Email Connection Attribute sign-up
    /// </summary>
    [JsonProperty("signup")]
    public ConnectionOptionsEmailSignup Signup { get; set; }
        
    /// <summary>
    /// Gets or sets the verification method for email.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("verification_method")]
    public ConnectionOptionsEmailVerificationMethod? VerificationMethod { get; set; }
}

/// <summary>
/// Verification methods for email authentication
/// </summary>
public enum ConnectionOptionsEmailVerificationMethod
{
    /// <summary>
    /// Use magic link for verification
    /// </summary>
    [EnumMember(Value = "link")]
    Link,

    /// <summary>
    /// Use one-time password for verification
    /// </summary>
    [EnumMember(Value = "otp")]
    Otp
}