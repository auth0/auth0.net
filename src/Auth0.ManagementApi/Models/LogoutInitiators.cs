using System.Runtime.Serialization;

namespace Auth0.ManagementApi.Models
{
    public enum LogoutInitiators
    {
        /// <summary>
        /// Request was initiated by a relying party (RP).
        /// </summary>
        [EnumMember(Value = "rp-logout")]
        RpLogout,

        /// <summary>
        /// Request was initiated by an external identity provider (IdP).
        /// </summary>
        [EnumMember(Value = "idp-logout")]
        IdpLogout,

        /// <summary>
        /// Request was initiated by a password change.
        /// </summary>
        [EnumMember(Value = "password-changed")]
        PasswordChanged,

        /// <summary>
        /// Request was initiated when a session expires.
        /// </summary>
        [EnumMember(Value = "session-expired")]
        SessionExpired
    }
}