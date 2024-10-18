using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    public enum GuardianEnrollmentStatus
    {
        [EnumMember(Value = "pending")]
        Pending,

        [EnumMember(Value = "confirmed")]
        Confirmed
    }
}