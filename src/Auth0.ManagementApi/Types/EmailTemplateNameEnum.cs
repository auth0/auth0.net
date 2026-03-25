using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EmailTemplateNameEnum.EmailTemplateNameEnumSerializer))]
[Serializable]
public readonly record struct EmailTemplateNameEnum : IStringEnum
{
    public static readonly EmailTemplateNameEnum VerifyEmail = new(Values.VerifyEmail);

    public static readonly EmailTemplateNameEnum VerifyEmailByCode = new(Values.VerifyEmailByCode);

    public static readonly EmailTemplateNameEnum ResetEmail = new(Values.ResetEmail);

    public static readonly EmailTemplateNameEnum ResetEmailByCode = new(Values.ResetEmailByCode);

    public static readonly EmailTemplateNameEnum WelcomeEmail = new(Values.WelcomeEmail);

    public static readonly EmailTemplateNameEnum BlockedAccount = new(Values.BlockedAccount);

    public static readonly EmailTemplateNameEnum StolenCredentials = new(Values.StolenCredentials);

    public static readonly EmailTemplateNameEnum EnrollmentEmail = new(Values.EnrollmentEmail);

    public static readonly EmailTemplateNameEnum MfaOobCode = new(Values.MfaOobCode);

    public static readonly EmailTemplateNameEnum UserInvitation = new(Values.UserInvitation);

    public static readonly EmailTemplateNameEnum ChangePassword = new(Values.ChangePassword);

    public static readonly EmailTemplateNameEnum PasswordReset = new(Values.PasswordReset);

    public static readonly EmailTemplateNameEnum AsyncApproval = new(Values.AsyncApproval);

    public EmailTemplateNameEnum(string value)
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
    public static EmailTemplateNameEnum FromCustom(string value)
    {
        return new EmailTemplateNameEnum(value);
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

    public static bool operator ==(EmailTemplateNameEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EmailTemplateNameEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EmailTemplateNameEnum value) => value.Value;

    public static explicit operator EmailTemplateNameEnum(string value) => new(value);

    internal class EmailTemplateNameEnumSerializer : JsonConverter<EmailTemplateNameEnum>
    {
        public override EmailTemplateNameEnum Read(
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
            return new EmailTemplateNameEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EmailTemplateNameEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string VerifyEmail = "verify_email";

        public const string VerifyEmailByCode = "verify_email_by_code";

        public const string ResetEmail = "reset_email";

        public const string ResetEmailByCode = "reset_email_by_code";

        public const string WelcomeEmail = "welcome_email";

        public const string BlockedAccount = "blocked_account";

        public const string StolenCredentials = "stolen_credentials";

        public const string EnrollmentEmail = "enrollment_email";

        public const string MfaOobCode = "mfa_oob_code";

        public const string UserInvitation = "user_invitation";

        public const string ChangePassword = "change_password";

        public const string PasswordReset = "password_reset";

        public const string AsyncApproval = "async_approval";
    }
}
