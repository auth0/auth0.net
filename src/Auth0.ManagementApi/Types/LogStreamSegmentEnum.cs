using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<LogStreamSegmentEnum>))]
[Serializable]
public readonly record struct LogStreamSegmentEnum : IStringEnum
{
    public static readonly LogStreamSegmentEnum Segment = new(Values.Segment);

    public LogStreamSegmentEnum(string value)
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
    public static LogStreamSegmentEnum FromCustom(string value)
    {
        return new LogStreamSegmentEnum(value);
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

    public static bool operator ==(LogStreamSegmentEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamSegmentEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamSegmentEnum value) => value.Value;

    public static explicit operator LogStreamSegmentEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Segment = "segment";
    }
}
