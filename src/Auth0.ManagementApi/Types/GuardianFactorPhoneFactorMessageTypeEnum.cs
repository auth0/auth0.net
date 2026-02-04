using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<GuardianFactorPhoneFactorMessageTypeEnum>))]
[Serializable]
public readonly record struct GuardianFactorPhoneFactorMessageTypeEnum : IStringEnum
{
    public static readonly GuardianFactorPhoneFactorMessageTypeEnum Sms = new(Values.Sms);

    public static readonly GuardianFactorPhoneFactorMessageTypeEnum Voice = new(Values.Voice);

    public GuardianFactorPhoneFactorMessageTypeEnum(string value)
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
    public static GuardianFactorPhoneFactorMessageTypeEnum FromCustom(string value)
    {
        return new GuardianFactorPhoneFactorMessageTypeEnum(value);
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
        GuardianFactorPhoneFactorMessageTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        GuardianFactorPhoneFactorMessageTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(GuardianFactorPhoneFactorMessageTypeEnum value) =>
        value.Value;

    public static explicit operator GuardianFactorPhoneFactorMessageTypeEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Sms = "sms";

        public const string Voice = "voice";
    }
}
