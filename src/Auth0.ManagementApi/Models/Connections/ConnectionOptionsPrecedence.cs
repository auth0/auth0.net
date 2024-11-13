using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models.Connections
{
    /// <summary>
    /// Represents the different Attribute types.
    /// </summary>
    public enum ConnectionOptionsPrecedence
    {
        [EnumMember(Value = "email")]
        Email,
        
        [EnumMember(Value = "phone_number")]
        PhoneNumber,
        
        [EnumMember(Value = "username")]
        UserName
    }
}