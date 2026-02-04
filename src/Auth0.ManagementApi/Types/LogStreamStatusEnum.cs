using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<LogStreamStatusEnum>))]
[Serializable]
public readonly record struct LogStreamStatusEnum : IStringEnum
{
    public static readonly LogStreamStatusEnum Active = new(Values.Active);

    public static readonly LogStreamStatusEnum Paused = new(Values.Paused);

    public static readonly LogStreamStatusEnum Suspended = new(Values.Suspended);

    public LogStreamStatusEnum(string value)
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
    public static LogStreamStatusEnum FromCustom(string value)
    {
        return new LogStreamStatusEnum(value);
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

    public static bool operator ==(LogStreamStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamStatusEnum value) => value.Value;

    public static explicit operator LogStreamStatusEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Active = "active";

        public const string Paused = "paused";

        public const string Suspended = "suspended";
    }
}
