using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    /// <summary>
    /// The names of the different email templates which you can manage.
    /// </summary>
    public enum EmailTemplateName
    {
        /// <summary>
        /// This email will be sent whenever a user signs up or logs in for the first time.
        /// </summary>
        [EnumMember(Value = "verify_email")]
        VerifyEmail,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "reset_email")]
        ResetEmail,

        /// <summary>
        /// This email will be sent once the user verifies their email address. 
        /// </summary>
        [EnumMember(Value = "welcome_email")]
        WelcomeEmail,

        /// <summary>
        /// This email will be sent whenever a user is blocked due to suspicious login attempts. 
        /// </summary>
        [EnumMember(Value = "blocked_account")]
        BlockedAccount,

        /// <summary>
        /// This email will be sent whenever Auth0 detects that the user is trying to access the application using a password that has been leaked by a third party. 
        /// </summary>
        [EnumMember(Value = "stolen_credentials")]
        StolenCredentials,

        /// <summary>
        /// This email will be sent when an admin sends a guardian enrollment email. 
        /// </summary>
        [EnumMember(Value = "enrollment_email")]
        EnrollmentEmail,

        /// <summary>
        /// This email will be sent whenever a user requests a password change.
        /// </summary>
        [EnumMember(Value = "change_password")]
        ChangePassword,

        /// <summary>
        /// This email will be sent whenever a user requests a password reset.
        /// </summary>
        [EnumMember(Value = "password_reset")]
        PasswordReset,

        /// <summary>
        /// This email will provide the MFA verification code to a user that is using a MFA email verifier. 
        /// </summary>
        [EnumMember(Value = "mfa_oob_code")]
        MfaOobCode
    }
}