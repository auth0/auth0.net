using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamFilterGroupNameEnum.LogStreamFilterGroupNameEnumSerializer))]
[Serializable]
public readonly record struct LogStreamFilterGroupNameEnum : IStringEnum
{
    public static readonly LogStreamFilterGroupNameEnum AuthLoginFail = new(Values.AuthLoginFail);

    public static readonly LogStreamFilterGroupNameEnum AuthLoginNotification = new(
        Values.AuthLoginNotification
    );

    public static readonly LogStreamFilterGroupNameEnum AuthLoginSuccess = new(
        Values.AuthLoginSuccess
    );

    public static readonly LogStreamFilterGroupNameEnum AuthLogoutFail = new(Values.AuthLogoutFail);

    public static readonly LogStreamFilterGroupNameEnum AuthLogoutSuccess = new(
        Values.AuthLogoutSuccess
    );

    public static readonly LogStreamFilterGroupNameEnum AuthSignupFail = new(Values.AuthSignupFail);

    public static readonly LogStreamFilterGroupNameEnum AuthSignupSuccess = new(
        Values.AuthSignupSuccess
    );

    public static readonly LogStreamFilterGroupNameEnum AuthSilentAuthFail = new(
        Values.AuthSilentAuthFail
    );

    public static readonly LogStreamFilterGroupNameEnum AuthSilentAuthSuccess = new(
        Values.AuthSilentAuthSuccess
    );

    public static readonly LogStreamFilterGroupNameEnum AuthTokenExchangeFail = new(
        Values.AuthTokenExchangeFail
    );

    public static readonly LogStreamFilterGroupNameEnum AuthTokenExchangeSuccess = new(
        Values.AuthTokenExchangeSuccess
    );

    public static readonly LogStreamFilterGroupNameEnum ManagementFail = new(Values.ManagementFail);

    public static readonly LogStreamFilterGroupNameEnum ManagementSuccess = new(
        Values.ManagementSuccess
    );

    public static readonly LogStreamFilterGroupNameEnum ScimEvent = new(Values.ScimEvent);

    public static readonly LogStreamFilterGroupNameEnum SystemNotification = new(
        Values.SystemNotification
    );

    public static readonly LogStreamFilterGroupNameEnum UserFail = new(Values.UserFail);

    public static readonly LogStreamFilterGroupNameEnum UserNotification = new(
        Values.UserNotification
    );

    public static readonly LogStreamFilterGroupNameEnum UserSuccess = new(Values.UserSuccess);

    public static readonly LogStreamFilterGroupNameEnum Actions = new(Values.Actions);

    public static readonly LogStreamFilterGroupNameEnum Other = new(Values.Other);

    public LogStreamFilterGroupNameEnum(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static LogStreamFilterGroupNameEnum FromCustom(string value)
    {
        return new LogStreamFilterGroupNameEnum(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(LogStreamFilterGroupNameEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamFilterGroupNameEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamFilterGroupNameEnum value) => value.Value;

    public static explicit operator LogStreamFilterGroupNameEnum(string value) => new(value);

    internal class LogStreamFilterGroupNameEnumSerializer
        : JsonConverter<LogStreamFilterGroupNameEnum>
    {
        public override LogStreamFilterGroupNameEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new LogStreamFilterGroupNameEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamFilterGroupNameEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LogStreamFilterGroupNameEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new LogStreamFilterGroupNameEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LogStreamFilterGroupNameEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AuthLoginFail = "auth.login.fail";

        public const string AuthLoginNotification = "auth.login.notification";

        public const string AuthLoginSuccess = "auth.login.success";

        public const string AuthLogoutFail = "auth.logout.fail";

        public const string AuthLogoutSuccess = "auth.logout.success";

        public const string AuthSignupFail = "auth.signup.fail";

        public const string AuthSignupSuccess = "auth.signup.success";

        public const string AuthSilentAuthFail = "auth.silent_auth.fail";

        public const string AuthSilentAuthSuccess = "auth.silent_auth.success";

        public const string AuthTokenExchangeFail = "auth.token_exchange.fail";

        public const string AuthTokenExchangeSuccess = "auth.token_exchange.success";

        public const string ManagementFail = "management.fail";

        public const string ManagementSuccess = "management.success";

        public const string ScimEvent = "scim.event";

        public const string SystemNotification = "system.notification";

        public const string UserFail = "user.fail";

        public const string UserNotification = "user.notification";

        public const string UserSuccess = "user.success";

        public const string Actions = "actions";

        public const string Other = "other";
    }
}
