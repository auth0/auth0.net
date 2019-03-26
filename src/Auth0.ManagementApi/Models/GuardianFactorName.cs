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
        Duo
    }
}
