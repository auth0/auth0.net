using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<BreachedPasswordDetectionShieldsEnum>))]
[Serializable]
public readonly record struct BreachedPasswordDetectionShieldsEnum : IStringEnum
{
    public static readonly BreachedPasswordDetectionShieldsEnum Block = new(Values.Block);

    public static readonly BreachedPasswordDetectionShieldsEnum UserNotification = new(
        Values.UserNotification
    );

    public static readonly BreachedPasswordDetectionShieldsEnum AdminNotification = new(
        Values.AdminNotification
    );

    public BreachedPasswordDetectionShieldsEnum(string value)
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
    public static BreachedPasswordDetectionShieldsEnum FromCustom(string value)
    {
        return new BreachedPasswordDetectionShieldsEnum(value);
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

    public static bool operator ==(BreachedPasswordDetectionShieldsEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(BreachedPasswordDetectionShieldsEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(BreachedPasswordDetectionShieldsEnum value) =>
        value.Value;

    public static explicit operator BreachedPasswordDetectionShieldsEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Block = "block";

        public const string UserNotification = "user_notification";

        public const string AdminNotification = "admin_notification";
    }
}
