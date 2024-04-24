using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    public enum TokenDialect
    {
        [EnumMember(Value = "access_token")]
        AccessToken,

        [EnumMember(Value = "access_token_authz")]
        AccessTokenAuthZ,
        
        [EnumMember(Value = "rfc9068_profile")]
        Rfc9068Profile,
        
        [EnumMember(Value = "rfc9068_profile_authz")]
        Rfc9068ProfileAuthz
    }
}