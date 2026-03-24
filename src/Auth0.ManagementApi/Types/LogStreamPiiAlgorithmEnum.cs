using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<LogStreamPiiAlgorithmEnum>))]
[Serializable]
public readonly record struct LogStreamPiiAlgorithmEnum : IStringEnum
{
    public static readonly LogStreamPiiAlgorithmEnum Xxhash = new(Values.Xxhash);

    public LogStreamPiiAlgorithmEnum(string value)
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
    public static LogStreamPiiAlgorithmEnum FromCustom(string value)
    {
        return new LogStreamPiiAlgorithmEnum(value);
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

    public static bool operator ==(LogStreamPiiAlgorithmEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamPiiAlgorithmEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamPiiAlgorithmEnum value) => value.Value;

    public static explicit operator LogStreamPiiAlgorithmEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Xxhash = "xxhash";
    }
}
