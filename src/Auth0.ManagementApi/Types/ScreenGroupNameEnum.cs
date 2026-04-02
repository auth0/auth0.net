using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ScreenGroupNameEnum.ScreenGroupNameEnumSerializer))]
[Serializable]
public readonly record struct ScreenGroupNameEnum : IStringEnum
{
    public static readonly ScreenGroupNameEnum Login = new(Values.Login);

    public static readonly ScreenGroupNameEnum LoginId = new(Values.LoginId);

    public static readonly ScreenGroupNameEnum LoginPassword = new(Values.LoginPassword);

    public static readonly ScreenGroupNameEnum LoginPasswordlessEmailCode = new(
        Values.LoginPasswordlessEmailCode
    );

    public static readonly ScreenGroupNameEnum LoginPasswordlessEmailLink = new(
        Values.LoginPasswordlessEmailLink
    );

    public static readonly ScreenGroupNameEnum LoginPasswordlessSmsOtp = new(
        Values.LoginPasswordlessSmsOtp
    );

    public static readonly ScreenGroupNameEnum LoginEmailVerification = new(
        Values.LoginEmailVerification
    );

    public static readonly ScreenGroupNameEnum Signup = new(Values.Signup);

    public static readonly ScreenGroupNameEnum SignupId = new(Values.SignupId);

    public static readonly ScreenGroupNameEnum SignupPassword = new(Values.SignupPassword);

    public static readonly ScreenGroupNameEnum PhoneIdentifierEnrollment = new(
        Values.PhoneIdentifierEnrollment
    );

    public static readonly ScreenGroupNameEnum PhoneIdentifierChallenge = new(
        Values.PhoneIdentifierChallenge
    );

    public static readonly ScreenGroupNameEnum EmailIdentifierChallenge = new(
        Values.EmailIdentifierChallenge
    );

    public static readonly ScreenGroupNameEnum ResetPasswordRequest = new(
        Values.ResetPasswordRequest
    );

    public static readonly ScreenGroupNameEnum ResetPasswordEmail = new(Values.ResetPasswordEmail);

    public static readonly ScreenGroupNameEnum ResetPassword = new(Values.ResetPassword);

    public static readonly ScreenGroupNameEnum ResetPasswordSuccess = new(
        Values.ResetPasswordSuccess
    );

    public static readonly ScreenGroupNameEnum ResetPasswordError = new(Values.ResetPasswordError);

    public static readonly ScreenGroupNameEnum ResetPasswordMfaEmailChallenge = new(
        Values.ResetPasswordMfaEmailChallenge
    );

    public static readonly ScreenGroupNameEnum ResetPasswordMfaOtpChallenge = new(
        Values.ResetPasswordMfaOtpChallenge
    );

    public static readonly ScreenGroupNameEnum ResetPasswordMfaPhoneChallenge = new(
        Values.ResetPasswordMfaPhoneChallenge
    );

    public static readonly ScreenGroupNameEnum ResetPasswordMfaPushChallengePush = new(
        Values.ResetPasswordMfaPushChallengePush
    );

    public static readonly ScreenGroupNameEnum ResetPasswordMfaRecoveryCodeChallenge = new(
        Values.ResetPasswordMfaRecoveryCodeChallenge
    );

    public static readonly ScreenGroupNameEnum ResetPasswordMfaSmsChallenge = new(
        Values.ResetPasswordMfaSmsChallenge
    );

    public static readonly ScreenGroupNameEnum ResetPasswordMfaVoiceChallenge = new(
        Values.ResetPasswordMfaVoiceChallenge
    );

    public static readonly ScreenGroupNameEnum ResetPasswordMfaWebauthnPlatformChallenge = new(
        Values.ResetPasswordMfaWebauthnPlatformChallenge
    );

    public static readonly ScreenGroupNameEnum ResetPasswordMfaWebauthnRoamingChallenge = new(
        Values.ResetPasswordMfaWebauthnRoamingChallenge
    );

    public static readonly ScreenGroupNameEnum CustomForm = new(Values.CustomForm);

    public static readonly ScreenGroupNameEnum Consent = new(Values.Consent);

    public static readonly ScreenGroupNameEnum CustomizedConsent = new(Values.CustomizedConsent);

    public static readonly ScreenGroupNameEnum Logout = new(Values.Logout);

    public static readonly ScreenGroupNameEnum LogoutComplete = new(Values.LogoutComplete);

    public static readonly ScreenGroupNameEnum LogoutAborted = new(Values.LogoutAborted);

    public static readonly ScreenGroupNameEnum MfaPushWelcome = new(Values.MfaPushWelcome);

    public static readonly ScreenGroupNameEnum MfaPushEnrollmentQr = new(
        Values.MfaPushEnrollmentQr
    );

    public static readonly ScreenGroupNameEnum MfaPushEnrollmentCode = new(
        Values.MfaPushEnrollmentCode
    );

    public static readonly ScreenGroupNameEnum MfaPushSuccess = new(Values.MfaPushSuccess);

    public static readonly ScreenGroupNameEnum MfaPushChallengePush = new(
        Values.MfaPushChallengePush
    );

    public static readonly ScreenGroupNameEnum MfaPushList = new(Values.MfaPushList);

    public static readonly ScreenGroupNameEnum MfaOtpEnrollmentQr = new(Values.MfaOtpEnrollmentQr);

    public static readonly ScreenGroupNameEnum MfaOtpEnrollmentCode = new(
        Values.MfaOtpEnrollmentCode
    );

    public static readonly ScreenGroupNameEnum MfaOtpChallenge = new(Values.MfaOtpChallenge);

    public static readonly ScreenGroupNameEnum MfaVoiceEnrollment = new(Values.MfaVoiceEnrollment);

    public static readonly ScreenGroupNameEnum MfaVoiceChallenge = new(Values.MfaVoiceChallenge);

    public static readonly ScreenGroupNameEnum MfaPhoneChallenge = new(Values.MfaPhoneChallenge);

    public static readonly ScreenGroupNameEnum MfaPhoneEnrollment = new(Values.MfaPhoneEnrollment);

    public static readonly ScreenGroupNameEnum MfaWebauthnPlatformEnrollment = new(
        Values.MfaWebauthnPlatformEnrollment
    );

    public static readonly ScreenGroupNameEnum MfaWebauthnRoamingEnrollment = new(
        Values.MfaWebauthnRoamingEnrollment
    );

    public static readonly ScreenGroupNameEnum MfaWebauthnPlatformChallenge = new(
        Values.MfaWebauthnPlatformChallenge
    );

    public static readonly ScreenGroupNameEnum MfaWebauthnRoamingChallenge = new(
        Values.MfaWebauthnRoamingChallenge
    );

    public static readonly ScreenGroupNameEnum MfaWebauthnChangeKeyNickname = new(
        Values.MfaWebauthnChangeKeyNickname
    );

    public static readonly ScreenGroupNameEnum MfaWebauthnEnrollmentSuccess = new(
        Values.MfaWebauthnEnrollmentSuccess
    );

    public static readonly ScreenGroupNameEnum MfaWebauthnError = new(Values.MfaWebauthnError);

    public static readonly ScreenGroupNameEnum MfaWebauthnNotAvailableError = new(
        Values.MfaWebauthnNotAvailableError
    );

    public static readonly ScreenGroupNameEnum MfaCountryCodes = new(Values.MfaCountryCodes);

    public static readonly ScreenGroupNameEnum MfaSmsEnrollment = new(Values.MfaSmsEnrollment);

    public static readonly ScreenGroupNameEnum MfaSmsChallenge = new(Values.MfaSmsChallenge);

    public static readonly ScreenGroupNameEnum MfaSmsList = new(Values.MfaSmsList);

    public static readonly ScreenGroupNameEnum MfaEmailChallenge = new(Values.MfaEmailChallenge);

    public static readonly ScreenGroupNameEnum MfaEmailList = new(Values.MfaEmailList);

    public static readonly ScreenGroupNameEnum MfaRecoveryCodeEnrollment = new(
        Values.MfaRecoveryCodeEnrollment
    );

    public static readonly ScreenGroupNameEnum MfaRecoveryCodeChallengeNewCode = new(
        Values.MfaRecoveryCodeChallengeNewCode
    );

    public static readonly ScreenGroupNameEnum MfaRecoveryCodeChallenge = new(
        Values.MfaRecoveryCodeChallenge
    );

    public static readonly ScreenGroupNameEnum MfaDetectBrowserCapabilities = new(
        Values.MfaDetectBrowserCapabilities
    );

    public static readonly ScreenGroupNameEnum MfaEnrollResult = new(Values.MfaEnrollResult);

    public static readonly ScreenGroupNameEnum MfaLoginOptions = new(Values.MfaLoginOptions);

    public static readonly ScreenGroupNameEnum MfaBeginEnrollOptions = new(
        Values.MfaBeginEnrollOptions
    );

    public static readonly ScreenGroupNameEnum Status = new(Values.Status);

    public static readonly ScreenGroupNameEnum DeviceCodeActivation = new(
        Values.DeviceCodeActivation
    );

    public static readonly ScreenGroupNameEnum DeviceCodeActivationAllowed = new(
        Values.DeviceCodeActivationAllowed
    );

    public static readonly ScreenGroupNameEnum DeviceCodeActivationDenied = new(
        Values.DeviceCodeActivationDenied
    );

    public static readonly ScreenGroupNameEnum DeviceCodeConfirmation = new(
        Values.DeviceCodeConfirmation
    );

    public static readonly ScreenGroupNameEnum EmailVerificationResult = new(
        Values.EmailVerificationResult
    );

    public static readonly ScreenGroupNameEnum EmailOtpChallenge = new(Values.EmailOtpChallenge);

    public static readonly ScreenGroupNameEnum OrganizationSelection = new(
        Values.OrganizationSelection
    );

    public static readonly ScreenGroupNameEnum OrganizationPicker = new(Values.OrganizationPicker);

    public static readonly ScreenGroupNameEnum PreLoginOrganizationPicker = new(
        Values.PreLoginOrganizationPicker
    );

    public static readonly ScreenGroupNameEnum AcceptInvitation = new(Values.AcceptInvitation);

    public static readonly ScreenGroupNameEnum RedeemTicket = new(Values.RedeemTicket);

    public static readonly ScreenGroupNameEnum PasskeyEnrollment = new(Values.PasskeyEnrollment);

    public static readonly ScreenGroupNameEnum PasskeyEnrollmentLocal = new(
        Values.PasskeyEnrollmentLocal
    );

    public static readonly ScreenGroupNameEnum InterstitialCaptcha = new(
        Values.InterstitialCaptcha
    );

    public static readonly ScreenGroupNameEnum BruteForceProtectionUnblock = new(
        Values.BruteForceProtectionUnblock
    );

    public static readonly ScreenGroupNameEnum BruteForceProtectionUnblockSuccess = new(
        Values.BruteForceProtectionUnblockSuccess
    );

    public static readonly ScreenGroupNameEnum BruteForceProtectionUnblockFailure = new(
        Values.BruteForceProtectionUnblockFailure
    );

    public static readonly ScreenGroupNameEnum AsyncApprovalError = new(Values.AsyncApprovalError);

    public static readonly ScreenGroupNameEnum AsyncApprovalAccepted = new(
        Values.AsyncApprovalAccepted
    );

    public static readonly ScreenGroupNameEnum AsyncApprovalDenied = new(
        Values.AsyncApprovalDenied
    );

    public static readonly ScreenGroupNameEnum AsyncApprovalWrongUser = new(
        Values.AsyncApprovalWrongUser
    );

    public ScreenGroupNameEnum(string value)
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
    public static ScreenGroupNameEnum FromCustom(string value)
    {
        return new ScreenGroupNameEnum(value);
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

    public static bool operator ==(ScreenGroupNameEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ScreenGroupNameEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ScreenGroupNameEnum value) => value.Value;

    public static explicit operator ScreenGroupNameEnum(string value) => new(value);

    internal class ScreenGroupNameEnumSerializer : JsonConverter<ScreenGroupNameEnum>
    {
        public override ScreenGroupNameEnum Read(
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
            return new ScreenGroupNameEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ScreenGroupNameEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ScreenGroupNameEnum ReadAsPropertyName(
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
            return new ScreenGroupNameEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ScreenGroupNameEnum value,
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
        public const string Login = "login";

        public const string LoginId = "login-id";

        public const string LoginPassword = "login-password";

        public const string LoginPasswordlessEmailCode = "login-passwordless-email-code";

        public const string LoginPasswordlessEmailLink = "login-passwordless-email-link";

        public const string LoginPasswordlessSmsOtp = "login-passwordless-sms-otp";

        public const string LoginEmailVerification = "login-email-verification";

        public const string Signup = "signup";

        public const string SignupId = "signup-id";

        public const string SignupPassword = "signup-password";

        public const string PhoneIdentifierEnrollment = "phone-identifier-enrollment";

        public const string PhoneIdentifierChallenge = "phone-identifier-challenge";

        public const string EmailIdentifierChallenge = "email-identifier-challenge";

        public const string ResetPasswordRequest = "reset-password-request";

        public const string ResetPasswordEmail = "reset-password-email";

        public const string ResetPassword = "reset-password";

        public const string ResetPasswordSuccess = "reset-password-success";

        public const string ResetPasswordError = "reset-password-error";

        public const string ResetPasswordMfaEmailChallenge = "reset-password-mfa-email-challenge";

        public const string ResetPasswordMfaOtpChallenge = "reset-password-mfa-otp-challenge";

        public const string ResetPasswordMfaPhoneChallenge = "reset-password-mfa-phone-challenge";

        public const string ResetPasswordMfaPushChallengePush =
            "reset-password-mfa-push-challenge-push";

        public const string ResetPasswordMfaRecoveryCodeChallenge =
            "reset-password-mfa-recovery-code-challenge";

        public const string ResetPasswordMfaSmsChallenge = "reset-password-mfa-sms-challenge";

        public const string ResetPasswordMfaVoiceChallenge = "reset-password-mfa-voice-challenge";

        public const string ResetPasswordMfaWebauthnPlatformChallenge =
            "reset-password-mfa-webauthn-platform-challenge";

        public const string ResetPasswordMfaWebauthnRoamingChallenge =
            "reset-password-mfa-webauthn-roaming-challenge";

        public const string CustomForm = "custom-form";

        public const string Consent = "consent";

        public const string CustomizedConsent = "customized-consent";

        public const string Logout = "logout";

        public const string LogoutComplete = "logout-complete";

        public const string LogoutAborted = "logout-aborted";

        public const string MfaPushWelcome = "mfa-push-welcome";

        public const string MfaPushEnrollmentQr = "mfa-push-enrollment-qr";

        public const string MfaPushEnrollmentCode = "mfa-push-enrollment-code";

        public const string MfaPushSuccess = "mfa-push-success";

        public const string MfaPushChallengePush = "mfa-push-challenge-push";

        public const string MfaPushList = "mfa-push-list";

        public const string MfaOtpEnrollmentQr = "mfa-otp-enrollment-qr";

        public const string MfaOtpEnrollmentCode = "mfa-otp-enrollment-code";

        public const string MfaOtpChallenge = "mfa-otp-challenge";

        public const string MfaVoiceEnrollment = "mfa-voice-enrollment";

        public const string MfaVoiceChallenge = "mfa-voice-challenge";

        public const string MfaPhoneChallenge = "mfa-phone-challenge";

        public const string MfaPhoneEnrollment = "mfa-phone-enrollment";

        public const string MfaWebauthnPlatformEnrollment = "mfa-webauthn-platform-enrollment";

        public const string MfaWebauthnRoamingEnrollment = "mfa-webauthn-roaming-enrollment";

        public const string MfaWebauthnPlatformChallenge = "mfa-webauthn-platform-challenge";

        public const string MfaWebauthnRoamingChallenge = "mfa-webauthn-roaming-challenge";

        public const string MfaWebauthnChangeKeyNickname = "mfa-webauthn-change-key-nickname";

        public const string MfaWebauthnEnrollmentSuccess = "mfa-webauthn-enrollment-success";

        public const string MfaWebauthnError = "mfa-webauthn-error";

        public const string MfaWebauthnNotAvailableError = "mfa-webauthn-not-available-error";

        public const string MfaCountryCodes = "mfa-country-codes";

        public const string MfaSmsEnrollment = "mfa-sms-enrollment";

        public const string MfaSmsChallenge = "mfa-sms-challenge";

        public const string MfaSmsList = "mfa-sms-list";

        public const string MfaEmailChallenge = "mfa-email-challenge";

        public const string MfaEmailList = "mfa-email-list";

        public const string MfaRecoveryCodeEnrollment = "mfa-recovery-code-enrollment";

        public const string MfaRecoveryCodeChallengeNewCode =
            "mfa-recovery-code-challenge-new-code";

        public const string MfaRecoveryCodeChallenge = "mfa-recovery-code-challenge";

        public const string MfaDetectBrowserCapabilities = "mfa-detect-browser-capabilities";

        public const string MfaEnrollResult = "mfa-enroll-result";

        public const string MfaLoginOptions = "mfa-login-options";

        public const string MfaBeginEnrollOptions = "mfa-begin-enroll-options";

        public const string Status = "status";

        public const string DeviceCodeActivation = "device-code-activation";

        public const string DeviceCodeActivationAllowed = "device-code-activation-allowed";

        public const string DeviceCodeActivationDenied = "device-code-activation-denied";

        public const string DeviceCodeConfirmation = "device-code-confirmation";

        public const string EmailVerificationResult = "email-verification-result";

        public const string EmailOtpChallenge = "email-otp-challenge";

        public const string OrganizationSelection = "organization-selection";

        public const string OrganizationPicker = "organization-picker";

        public const string PreLoginOrganizationPicker = "pre-login-organization-picker";

        public const string AcceptInvitation = "accept-invitation";

        public const string RedeemTicket = "redeem-ticket";

        public const string PasskeyEnrollment = "passkey-enrollment";

        public const string PasskeyEnrollmentLocal = "passkey-enrollment-local";

        public const string InterstitialCaptcha = "interstitial-captcha";

        public const string BruteForceProtectionUnblock = "brute-force-protection-unblock";

        public const string BruteForceProtectionUnblockSuccess =
            "brute-force-protection-unblock-success";

        public const string BruteForceProtectionUnblockFailure =
            "brute-force-protection-unblock-failure";

        public const string AsyncApprovalError = "async-approval-error";

        public const string AsyncApprovalAccepted = "async-approval-accepted";

        public const string AsyncApprovalDenied = "async-approval-denied";

        public const string AsyncApprovalWrongUser = "async-approval-wrong-user";
    }
}
