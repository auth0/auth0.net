using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(StringEnumSerializer<BreachedPasswordDetectionPreUserRegistrationShieldsEnum>)
)]
[Serializable]
public readonly record struct BreachedPasswordDetectionPreUserRegistrationShieldsEnum : IStringEnum
{
    public static readonly BreachedPasswordDetectionPreUserRegistrationShieldsEnum Block = new(
        Values.Block
    );

    public static readonly BreachedPasswordDetectionPreUserRegistrationShieldsEnum AdminNotification =
        new(Values.AdminNotification);

    public BreachedPasswordDetectionPreUserRegistrationShieldsEnum(string value)
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
    public static BreachedPasswordDetectionPreUserRegistrationShieldsEnum FromCustom(string value)
    {
        return new BreachedPasswordDetectionPreUserRegistrationShieldsEnum(value);
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
        BreachedPasswordDetectionPreUserRegistrationShieldsEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        BreachedPasswordDetectionPreUserRegistrationShieldsEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        BreachedPasswordDetectionPreUserRegistrationShieldsEnum value
    ) => value.Value;

    public static explicit operator BreachedPasswordDetectionPreUserRegistrationShieldsEnum(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Block = "block";

        public const string AdminNotification = "admin_notification";
    }
}
