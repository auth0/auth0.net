using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Auth0.ManagementApi.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogStreamFilterName
    {
        [EnumMember(Value = "auth.ancillary.fail")]
        AncillaryFailure,
        [EnumMember(Value = "auth.ancillary.success")]
        AncillarySuccess,
        [EnumMember(Value = "auth.login.fail")]
        LoginFailure,
        [EnumMember(Value = "auth.login.notification")]
        LoginNotification,
        [EnumMember(Value = "auth.login.success")]
        LoginSuccess,
        [EnumMember(Value = "auth.logout.fail")]
        LogoutFailure,
        [EnumMember(Value = "auth.logout.success")]
        LogoutSuccess,
        [EnumMember(Value = "auth.signup.fail")]
        SignupFailure,
        [EnumMember(Value = "auth.signup.success")]
        SignupSuccess,
        [EnumMember(Value = "auth.silent_auth.fail")]
        SilentAuthenticationFailure,
        [EnumMember(Value = "auth.silent_auth.success")]
        SilentAuthenticationSuccess,
        [EnumMember(Value = "auth.token_exchange.fail")]
        TokenExchangeFailure,
        [EnumMember(Value = "auth.token_exchange.success")]
        TokenExchangeSuccess,
        [EnumMember(Value = "management.fail")]
        ManagementApiFailure,
        [EnumMember(Value = "management.success")]
        ManagementApiSuccess,
        [EnumMember(Value = "system.notification")]
        SystemNotification,
        [EnumMember(Value = "user.fail")]
        UserFailure,
        [EnumMember(Value = "user.success")]
        UserSuccess,
        [EnumMember(Value = "user.notification")]
        UserNotification,
        [EnumMember(Value = "scim.event")]
        ScimEvent,
        [EnumMember(Value = "other")]
        Other,
    }
}
