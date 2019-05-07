using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    public enum TokenDialect
    {
        [EnumMember(Value = "access_token")]
        AccessToken,

        [EnumMember(Value = "access_token_authz")]
        AccessTokenAuthZ
    }
}