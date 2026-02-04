using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<GuardianFactorNameEnum>))]
[Serializable]
public readonly record struct GuardianFactorNameEnum : IStringEnum
{
    public static readonly GuardianFactorNameEnum PushNotification = new(Values.PushNotification);

    public static readonly GuardianFactorNameEnum Sms = new(Values.Sms);

    public static readonly GuardianFactorNameEnum Email = new(Values.Email);

    public static readonly GuardianFactorNameEnum Duo = new(Values.Duo);

    public static readonly GuardianFactorNameEnum Otp = new(Values.Otp);

    public static readonly GuardianFactorNameEnum WebauthnRoaming = new(Values.WebauthnRoaming);

    public static readonly GuardianFactorNameEnum WebauthnPlatform = new(Values.WebauthnPlatform);

    public static readonly GuardianFactorNameEnum RecoveryCode = new(Values.RecoveryCode);

    public GuardianFactorNameEnum(string value)
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
    public static GuardianFactorNameEnum FromCustom(string value)
    {
        return new GuardianFactorNameEnum(value);
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

    public static bool operator ==(GuardianFactorNameEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(GuardianFactorNameEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(GuardianFactorNameEnum value) => value.Value;

    public static explicit operator GuardianFactorNameEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string PushNotification = "push-notification";

        public const string Sms = "sms";

        public const string Email = "email";

        public const string Duo = "duo";

        public const string Otp = "otp";

        public const string WebauthnRoaming = "webauthn-roaming";

        public const string WebauthnPlatform = "webauthn-platform";

        public const string RecoveryCode = "recovery-code";
    }
}
