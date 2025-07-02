using System;
using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Sessions;

/// <summary>
/// Authentication signal details
/// </summary>
public class AuthenticationMethods
{
    /// <summary>
    /// One of: "federated", "passkey", "pwd", "sms", "email", "mfa", "mock" or a custom method denoted by a URL
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }
        
    /// <summary>
    /// Timestamp of when the signal was received
    /// </summary>
    [JsonProperty("timestamp")]
    public DateTime? Timestamp { get; set; }
        
    /// <summary>
    /// A specific MFA factor. Only present when "name" is set to "mfa"
    /// </summary>
    [JsonProperty("^type$")]
    public string Type { get; set; }
}