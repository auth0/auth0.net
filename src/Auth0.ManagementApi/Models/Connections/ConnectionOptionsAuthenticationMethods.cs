using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// Options for enabling authentication methods.
/// </summary>
public class ConnectionOptionsAuthenticationMethods
{
    /// <inheritdoc cref="ConnectionOptionsPasswordAuthenticationMethod"/> 
    [JsonProperty("password")]
    public ConnectionOptionsPasswordAuthenticationMethod Password { get; set; }
        
    /// <inheritdoc cref="ConnectionOptionsPasskeyAuthenticationMethod"/>
    [JsonProperty("passkey")]
    public ConnectionOptionsPasskeyAuthenticationMethod Passkey { get; set; }
}

public class ConnectionOptionsAuthenticationMethodsBase
{
    [JsonProperty("enabled")]
    public bool? Enabled { get; set; }
}
    
/// <summary>
/// Password authentication enablement
/// </summary>
public class ConnectionOptionsPasswordAuthenticationMethod : ConnectionOptionsAuthenticationMethodsBase
{
    /// <inheritdoc cref="ConnectionOptionsPasswordAuthenticationMethodApiBehavior"/>
    [JsonProperty("api_behavior")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ConnectionOptionsPasswordAuthenticationMethodApiBehavior? ApiBehavior { get; set; }
    
    /// <inheritdoc cref="ConnectionOptionsPasswordAuthenticationMethodSignupBehavior"/>
    [JsonProperty("signup_behavior")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ConnectionOptionsPasswordAuthenticationMethodSignupBehavior? SignupBehavior { get; set; }
    
    /// <summary>
    /// Email OTP authentication enablement
    /// </summary>
    [JsonProperty("email_otp")]
    public ConnectionOptionsEmailOtpAuthenticationMethod EmailOtp { get; set; }
    
    /// <summary>
    /// Phone OTP authentication enablement
    /// </summary>
    [JsonProperty("phone_otp")]
    public ConnectionOptionsPhoneOtpAuthenticationMethod PhoneOtp { get; set; }
}

/// <summary>
/// Specifies the API behavior for password authentication
/// </summary>
public enum ConnectionOptionsPasswordAuthenticationMethodApiBehavior
{
    [EnumMember(Value = "required")]
    Required,
    
    [EnumMember(Value = "optional")]
    Optional
}

/// <summary>
/// Specifies the signup behavior for password authentication
/// </summary>
public enum ConnectionOptionsPasswordAuthenticationMethodSignupBehavior
{
    [EnumMember(Value = "allow")]
    Allow,
    
    [EnumMember(Value = "block")]
    Block,
}

/// <summary>
/// Passkey authentication enablement
/// </summary>
public class ConnectionOptionsPasskeyAuthenticationMethod : ConnectionOptionsAuthenticationMethodsBase
{
        
}

/// <summary>
/// Email OTP authentication enablement
/// </summary>
public class ConnectionOptionsEmailOtpAuthenticationMethod : ConnectionOptionsAuthenticationMethodsBase
{
    
}

/// <summary>
/// Phone OTP authentication enablement
/// </summary>
public class ConnectionOptionsPhoneOtpAuthenticationMethod : ConnectionOptionsAuthenticationMethodsBase
{
        
}