using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ClientOidcBackchannelLogoutInitiatorsEnum>))]
[Serializable]
public readonly record struct ClientOidcBackchannelLogoutInitiatorsEnum : IStringEnum
{
    public static readonly ClientOidcBackchannelLogoutInitiatorsEnum RpLogout = new(
        Values.RpLogout
    );

    public static readonly ClientOidcBackchannelLogoutInitiatorsEnum IdpLogout = new(
        Values.IdpLogout
    );

    public static readonly ClientOidcBackchannelLogoutInitiatorsEnum PasswordChanged = new(
        Values.PasswordChanged
    );

    public static readonly ClientOidcBackchannelLogoutInitiatorsEnum SessionExpired = new(
        Values.SessionExpired
    );

    public static readonly ClientOidcBackchannelLogoutInitiatorsEnum SessionRevoked = new(
        Values.SessionRevoked
    );

    public static readonly ClientOidcBackchannelLogoutInitiatorsEnum AccountDeleted = new(
        Values.AccountDeleted
    );

    public static readonly ClientOidcBackchannelLogoutInitiatorsEnum EmailIdentifierChanged = new(
        Values.EmailIdentifierChanged
    );

    public static readonly ClientOidcBackchannelLogoutInitiatorsEnum MfaPhoneUnenrolled = new(
        Values.MfaPhoneUnenrolled
    );

    public static readonly ClientOidcBackchannelLogoutInitiatorsEnum AccountDeactivated = new(
        Values.AccountDeactivated
    );

    public ClientOidcBackchannelLogoutInitiatorsEnum(string value)
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
    public static ClientOidcBackchannelLogoutInitiatorsEnum FromCustom(string value)
    {
        return new ClientOidcBackchannelLogoutInitiatorsEnum(value);
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

    public static bool operator ==(
        ClientOidcBackchannelLogoutInitiatorsEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientOidcBackchannelLogoutInitiatorsEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ClientOidcBackchannelLogoutInitiatorsEnum value) =>
        value.Value;

    public static explicit operator ClientOidcBackchannelLogoutInitiatorsEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string RpLogout = "rp-logout";

        public const string IdpLogout = "idp-logout";

        public const string PasswordChanged = "password-changed";

        public const string SessionExpired = "session-expired";

        public const string SessionRevoked = "session-revoked";

        public const string AccountDeleted = "account-deleted";

        public const string EmailIdentifierChanged = "email-identifier-changed";

        public const string MfaPhoneUnenrolled = "mfa-phone-unenrolled";

        public const string AccountDeactivated = "account-deactivated";
    }
}
