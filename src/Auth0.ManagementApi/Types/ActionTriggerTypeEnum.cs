using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ActionTriggerTypeEnum.ActionTriggerTypeEnumSerializer))]
[Serializable]
public readonly record struct ActionTriggerTypeEnum : IStringEnum
{
    public static readonly ActionTriggerTypeEnum PostLogin = new(Values.PostLogin);

    public static readonly ActionTriggerTypeEnum CredentialsExchange = new(
        Values.CredentialsExchange
    );

    public static readonly ActionTriggerTypeEnum PreUserRegistration = new(
        Values.PreUserRegistration
    );

    public static readonly ActionTriggerTypeEnum PostUserRegistration = new(
        Values.PostUserRegistration
    );

    public static readonly ActionTriggerTypeEnum PostChangePassword = new(
        Values.PostChangePassword
    );

    public static readonly ActionTriggerTypeEnum SendPhoneMessage = new(Values.SendPhoneMessage);

    public static readonly ActionTriggerTypeEnum CustomPhoneProvider = new(
        Values.CustomPhoneProvider
    );

    public static readonly ActionTriggerTypeEnum CustomEmailProvider = new(
        Values.CustomEmailProvider
    );

    public static readonly ActionTriggerTypeEnum PasswordResetPostChallenge = new(
        Values.PasswordResetPostChallenge
    );

    public static readonly ActionTriggerTypeEnum CustomTokenExchange = new(
        Values.CustomTokenExchange
    );

    public static readonly ActionTriggerTypeEnum EventStream = new(Values.EventStream);

    public static readonly ActionTriggerTypeEnum PasswordHashMigration = new(
        Values.PasswordHashMigration
    );

    public static readonly ActionTriggerTypeEnum LoginPostIdentifier = new(
        Values.LoginPostIdentifier
    );

    public static readonly ActionTriggerTypeEnum SignupPostIdentifier = new(
        Values.SignupPostIdentifier
    );

    public ActionTriggerTypeEnum(string value)
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
    public static ActionTriggerTypeEnum FromCustom(string value)
    {
        return new ActionTriggerTypeEnum(value);
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

    public static bool operator ==(ActionTriggerTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActionTriggerTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActionTriggerTypeEnum value) => value.Value;

    public static explicit operator ActionTriggerTypeEnum(string value) => new(value);

    internal class ActionTriggerTypeEnumSerializer : JsonConverter<ActionTriggerTypeEnum>
    {
        public override ActionTriggerTypeEnum Read(
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
            return new ActionTriggerTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ActionTriggerTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ActionTriggerTypeEnum ReadAsPropertyName(
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
            return new ActionTriggerTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ActionTriggerTypeEnum value,
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
        public const string PostLogin = "post-login";

        public const string CredentialsExchange = "credentials-exchange";

        public const string PreUserRegistration = "pre-user-registration";

        public const string PostUserRegistration = "post-user-registration";

        public const string PostChangePassword = "post-change-password";

        public const string SendPhoneMessage = "send-phone-message";

        public const string CustomPhoneProvider = "custom-phone-provider";

        public const string CustomEmailProvider = "custom-email-provider";

        public const string PasswordResetPostChallenge = "password-reset-post-challenge";

        public const string CustomTokenExchange = "custom-token-exchange";

        public const string EventStream = "event-stream";

        public const string PasswordHashMigration = "password-hash-migration";

        public const string LoginPostIdentifier = "login-post-identifier";

        public const string SignupPostIdentifier = "signup-post-identifier";
    }
}
