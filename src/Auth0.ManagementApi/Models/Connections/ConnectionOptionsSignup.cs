using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.Connections;

public class ConnectionOptionsSignupBase
{
    /// <inheritdoc cref="ConnectionOptionsAttributeStatus"/>
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("status")]
    public ConnectionOptionsAttributeStatus Status { get; set; }
}
    
/// <summary>
/// Sign-up Status 
/// </summary>
public enum ConnectionOptionsAttributeStatus
{
    [EnumMember(Value = "required")]
    Required,
        
    [EnumMember(Value = "optional")]
    Optional,
        
    [EnumMember(Value = "inactive")]
    Inactive
}

/// <summary>
/// Signup Verification
/// </summary>
public class ConnectionOptionsVerification
{
    [JsonProperty("active")]
    public bool? Active { get; set; }
}
    
/// <summary>
/// Phone number attribute signup
/// </summary>
public class ConnectionOptionsPhoneNumberSignup : ConnectionOptionsSignupBase
{
    /// <inheritdoc cref="ConnectionOptionsVerification"/>
    [JsonProperty("verification")]
    public ConnectionOptionsVerification Verification { get; set; }
}
    
/// <summary>
/// Email Attribute signup
/// </summary>
public class ConnectionOptionsEmailSignup : ConnectionOptionsSignupBase
{
    /// <inheritdoc cref="ConnectionOptionsVerification"/>
    [JsonProperty("verification")]
    public ConnectionOptionsVerification Verification { get; set; }
}

/// <summary>
/// Username attribute signup
/// </summary>
public class ConnectionOptionsUsernameSignup : ConnectionOptionsSignupBase
{
        
}