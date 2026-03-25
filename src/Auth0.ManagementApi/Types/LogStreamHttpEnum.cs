using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamHttpEnum.LogStreamHttpEnumSerializer))]
[Serializable]
public readonly record struct LogStreamHttpEnum : IStringEnum
{
    public static readonly LogStreamHttpEnum Http = new(Values.Http);

    public LogStreamHttpEnum(string value)
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
    public static LogStreamHttpEnum FromCustom(string value)
    {
        return new LogStreamHttpEnum(value);
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

    public static bool operator ==(LogStreamHttpEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamHttpEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamHttpEnum value) => value.Value;

    public static explicit operator LogStreamHttpEnum(string value) => new(value);

    internal class LogStreamHttpEnumSerializer : JsonConverter<LogStreamHttpEnum>
    {
        public override LogStreamHttpEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new LogStreamHttpEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamHttpEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Http = "http";
    }
}
