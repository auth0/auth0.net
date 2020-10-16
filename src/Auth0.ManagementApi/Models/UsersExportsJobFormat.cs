using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    public enum UsersExportsJobFormat
    {
        [EnumMember(Value = "csv")]
        CSV,
        [EnumMember(Value = "json")]
        Json
    }
}
