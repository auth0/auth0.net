using Newtonsoft.Json;

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
    
}

/// <summary>
/// Passkey authentication enablement
/// </summary>
public class ConnectionOptionsPasskeyAuthenticationMethod : ConnectionOptionsAuthenticationMethodsBase
{
        
}