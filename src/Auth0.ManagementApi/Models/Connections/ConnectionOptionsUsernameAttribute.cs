using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// Configuration for the username attribute for users.
/// </summary>
public class ConnectionOptionsUsernameAttribute : ConnectionOptionsAttributeBase
{
    /// <inheritdoc cref="ConnectionOptionsUsernameSignup"/>
    [JsonProperty("signup")]
    public ConnectionOptionsUsernameSignup Signup { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsAttributeValidation"/> 
    [JsonProperty("validation")]
    public ConnectionOptionsAttributeValidation Validation { get; set; }
}