using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models.Actions;

/// <summary>
/// Represents the type of the integration.
/// </summary>
public enum FeatureType
{
    [EnumMember(Value = "unspecified")]
    Unspecified,
        
    [EnumMember(Value = "action")]
    Action,
        
    [EnumMember(Value = "social_connection")]
    SocialConnection,
        
    [EnumMember(Value = "log_stream")]
    LogStream,
        
    [EnumMember(Value = "sso_integration")]
    SsoIntegration,
        
    [EnumMember(Value = "sms_provider")]
    SmsProvider,
}