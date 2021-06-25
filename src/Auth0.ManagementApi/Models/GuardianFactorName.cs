using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    public enum GuardianFactorName
    {
        [EnumMember(Value = "sms")]
        Sms,

        [EnumMember(Value = "push-notification")]
        PushNotifications,

        [EnumMember(Value = "email")]
        Email,

        [EnumMember(Value = "otp")]
        Otp,

        [EnumMember(Value = "duo")]
        Duo,
        
        [EnumMember(Value="webauthn-roaming")]
        WebAuthnRoaming,
        
        [EnumMember(Value="webauthn-platform")]
        WebAuthnPlatform,

        [EnumMember(Value= "recovery-code")]
        RecoveryCode
    }
}
