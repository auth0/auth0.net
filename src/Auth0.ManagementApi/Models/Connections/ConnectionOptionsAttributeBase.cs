using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models.Connections;

/// <summary>
/// 
/// </summary>
public class ConnectionOptionsAttributeBase
{
    [JsonProperty("identifier")]
    public ConnectionOptionsAttributeIdentifier Identifier { get; set; }
        
    /// <summary>
    /// Determines if property should be required for users
    /// </summary>
    [JsonProperty("profile_required")]
    public bool? ProfileRequired { get; set; }
}

public class ConnectionOptionsAttributeIdentifier
{
    /// <summary>
    /// Determines if the attribute is used for identification
    /// </summary>
    [JsonProperty("active")]
    public bool? Active { get; set; }

    /// <inheritdoc cref="ConnectionOptionsAttributeDefaultMethod"/>
    [JsonProperty("default_method")]
    [JsonConverter(typeof(StringEnumConverter))]
    public ConnectionOptionsAttributeDefaultMethod? DefaultMethod { get; set; }
}

/// <summary>
/// Default authentication method for email identifier
/// </summary>
public enum ConnectionOptionsAttributeDefaultMethod
{
    [EnumMember(Value ="password")]
    Password,

    [EnumMember(Value ="email_otp")]
    EmailOtp
}