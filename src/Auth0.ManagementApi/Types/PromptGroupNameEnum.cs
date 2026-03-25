using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(PromptGroupNameEnum.PromptGroupNameEnumSerializer))]
[Serializable]
public readonly record struct PromptGroupNameEnum : IStringEnum
{
    public static readonly PromptGroupNameEnum Login = new(Values.Login);

    public static readonly PromptGroupNameEnum LoginId = new(Values.LoginId);

    public static readonly PromptGroupNameEnum LoginPassword = new(Values.LoginPassword);

    public static readonly PromptGroupNameEnum LoginPasswordless = new(Values.LoginPasswordless);

    public static readonly PromptGroupNameEnum LoginEmailVerification = new(
        Values.LoginEmailVerification
    );

    public static readonly PromptGroupNameEnum Signup = new(Values.Signup);

    public static readonly PromptGroupNameEnum SignupId = new(Values.SignupId);

    public static readonly PromptGroupNameEnum SignupPassword = new(Values.SignupPassword);

    public static readonly PromptGroupNameEnum PhoneIdentifierEnrollment = new(
        Values.PhoneIdentifierEnrollment
    );

    public static readonly PromptGroupNameEnum PhoneIdentifierChallenge = new(
        Values.PhoneIdentifierChallenge
    );

    public static readonly PromptGroupNameEnum EmailIdentifierChallenge = new(
        Values.EmailIdentifierChallenge
    );

    public static readonly PromptGroupNameEnum ResetPassword = new(Values.ResetPassword);

    public static readonly PromptGroupNameEnum CustomForm = new(Values.CustomForm);

    public static readonly PromptGroupNameEnum Consent = new(Values.Consent);

    public static readonly PromptGroupNameEnum CustomizedConsent = new(Values.CustomizedConsent);

    public static readonly PromptGroupNameEnum Logout = new(Values.Logout);

    public static readonly PromptGroupNameEnum MfaPush = new(Values.MfaPush);

    public static readonly PromptGroupNameEnum MfaOtp = new(Values.MfaOtp);

    public static readonly PromptGroupNameEnum MfaVoice = new(Values.MfaVoice);

    public static readonly PromptGroupNameEnum MfaPhone = new(Values.MfaPhone);

    public static readonly PromptGroupNameEnum MfaWebauthn = new(Values.MfaWebauthn);

    public static readonly PromptGroupNameEnum MfaSms = new(Values.MfaSms);

    public static readonly PromptGroupNameEnum MfaEmail = new(Values.MfaEmail);

    public static readonly PromptGroupNameEnum MfaRecoveryCode = new(Values.MfaRecoveryCode);

    public static readonly PromptGroupNameEnum Mfa = new(Values.Mfa);

    public static readonly PromptGroupNameEnum Status = new(Values.Status);

    public static readonly PromptGroupNameEnum DeviceFlow = new(Values.DeviceFlow);

    public static readonly PromptGroupNameEnum EmailVerification = new(Values.EmailVerification);

    public static readonly PromptGroupNameEnum EmailOtpChallenge = new(Values.EmailOtpChallenge);

    public static readonly PromptGroupNameEnum Organizations = new(Values.Organizations);

    public static readonly PromptGroupNameEnum Invitation = new(Values.Invitation);

    public static readonly PromptGroupNameEnum Common = new(Values.Common);

    public static readonly PromptGroupNameEnum Passkeys = new(Values.Passkeys);

    public static readonly PromptGroupNameEnum Captcha = new(Values.Captcha);

    public static readonly PromptGroupNameEnum BruteForceProtection = new(
        Values.BruteForceProtection
    );

    public static readonly PromptGroupNameEnum AsyncApprovalFlow = new(Values.AsyncApprovalFlow);

    public PromptGroupNameEnum(string value)
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
    public static PromptGroupNameEnum FromCustom(string value)
    {
        return new PromptGroupNameEnum(value);
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

    public static bool operator ==(PromptGroupNameEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PromptGroupNameEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PromptGroupNameEnum value) => value.Value;

    public static explicit operator PromptGroupNameEnum(string value) => new(value);

    internal class PromptGroupNameEnumSerializer : JsonConverter<PromptGroupNameEnum>
    {
        public override PromptGroupNameEnum Read(
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
            return new PromptGroupNameEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            PromptGroupNameEnum value,
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
        public const string Login = "login";

        public const string LoginId = "login-id";

        public const string LoginPassword = "login-password";

        public const string LoginPasswordless = "login-passwordless";

        public const string LoginEmailVerification = "login-email-verification";

        public const string Signup = "signup";

        public const string SignupId = "signup-id";

        public const string SignupPassword = "signup-password";

        public const string PhoneIdentifierEnrollment = "phone-identifier-enrollment";

        public const string PhoneIdentifierChallenge = "phone-identifier-challenge";

        public const string EmailIdentifierChallenge = "email-identifier-challenge";

        public const string ResetPassword = "reset-password";

        public const string CustomForm = "custom-form";

        public const string Consent = "consent";

        public const string CustomizedConsent = "customized-consent";

        public const string Logout = "logout";

        public const string MfaPush = "mfa-push";

        public const string MfaOtp = "mfa-otp";

        public const string MfaVoice = "mfa-voice";

        public const string MfaPhone = "mfa-phone";

        public const string MfaWebauthn = "mfa-webauthn";

        public const string MfaSms = "mfa-sms";

        public const string MfaEmail = "mfa-email";

        public const string MfaRecoveryCode = "mfa-recovery-code";

        public const string Mfa = "mfa";

        public const string Status = "status";

        public const string DeviceFlow = "device-flow";

        public const string EmailVerification = "email-verification";

        public const string EmailOtpChallenge = "email-otp-challenge";

        public const string Organizations = "organizations";

        public const string Invitation = "invitation";

        public const string Common = "common";

        public const string Passkeys = "passkeys";

        public const string Captcha = "captcha";

        public const string BruteForceProtection = "brute-force-protection";

        public const string AsyncApprovalFlow = "async-approval-flow";
    }
}
