using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Auth0.ManagementApi.Models
{
    public enum GuardianFactorName
    {
        [EnumMember(Value = "sms")]
        Sms,

        [EnumMember(Value = "push-notification")]
        PushNotifications
    }
}
