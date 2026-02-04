using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BotDetectionLevelEnum>))]
[Serializable]
public readonly record struct BotDetectionLevelEnum : IStringEnum
{
    public static readonly BotDetectionLevelEnum Low = new(Values.Low);

    public static readonly BotDetectionLevelEnum Medium = new(Values.Medium);

    public static readonly BotDetectionLevelEnum High = new(Values.High);

    public BotDetectionLevelEnum(string value)
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
    public static BotDetectionLevelEnum FromCustom(string value)
    {
        return new BotDetectionLevelEnum(value);
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

    public static bool operator ==(BotDetectionLevelEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BotDetectionLevelEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BotDetectionLevelEnum value) => value.Value;

    public static explicit operator BotDetectionLevelEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Low = "low";

        public const string Medium = "medium";

        public const string High = "high";
    }
}
