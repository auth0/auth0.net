using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BruteForceProtectionShieldsEnum>))]
[Serializable]
public readonly record struct BruteForceProtectionShieldsEnum : IStringEnum
{
    public static readonly BruteForceProtectionShieldsEnum Block = new(Values.Block);

    public static readonly BruteForceProtectionShieldsEnum UserNotification = new(
        Values.UserNotification
    );

    public BruteForceProtectionShieldsEnum(string value)
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
    public static BruteForceProtectionShieldsEnum FromCustom(string value)
    {
        return new BruteForceProtectionShieldsEnum(value);
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

    public static bool operator ==(BruteForceProtectionShieldsEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BruteForceProtectionShieldsEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BruteForceProtectionShieldsEnum value) => value.Value;

    public static explicit operator BruteForceProtectionShieldsEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Block = "block";

        public const string UserNotification = "user_notification";
    }
}
