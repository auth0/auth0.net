using Newtonsoft.Json;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// Attribute Configuration
/// </summary>
public class ConnectionOptionsAttributes
{
    /// <inheritdoc cref="ConnectionOptionsEmailAttribute"/>
    [JsonProperty("email")]
    public ConnectionOptionsEmailAttribute Email { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsPhoneNumberAttribute"/>
    [JsonProperty("phone_number")] 
    public ConnectionOptionsPhoneNumberAttribute PhoneNumber { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsUsernameAttribute"/>
    [JsonProperty("username")]
    public ConnectionOptionsUsernameAttribute Username { get; set; }
}