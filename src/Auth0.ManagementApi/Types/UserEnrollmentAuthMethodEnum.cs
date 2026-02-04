using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<UserEnrollmentAuthMethodEnum>))]
[Serializable]
public readonly record struct UserEnrollmentAuthMethodEnum : IStringEnum
{
    public static readonly UserEnrollmentAuthMethodEnum Authenticator = new(Values.Authenticator);

    public static readonly UserEnrollmentAuthMethodEnum Guardian = new(Values.Guardian);

    public static readonly UserEnrollmentAuthMethodEnum Sms = new(Values.Sms);

    public static readonly UserEnrollmentAuthMethodEnum WebauthnPlatform = new(
        Values.WebauthnPlatform
    );

    public static readonly UserEnrollmentAuthMethodEnum WebauthnRoaming = new(
        Values.WebauthnRoaming
    );

    public UserEnrollmentAuthMethodEnum(string value)
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
    public static UserEnrollmentAuthMethodEnum FromCustom(string value)
    {
        return new UserEnrollmentAuthMethodEnum(value);
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

    public static bool operator ==(UserEnrollmentAuthMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UserEnrollmentAuthMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UserEnrollmentAuthMethodEnum value) => value.Value;

    public static explicit operator UserEnrollmentAuthMethodEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Authenticator = "authenticator";

        public const string Guardian = "guardian";

        public const string Sms = "sms";

        public const string WebauthnPlatform = "webauthn-platform";

        public const string WebauthnRoaming = "webauthn-roaming";
    }
}
