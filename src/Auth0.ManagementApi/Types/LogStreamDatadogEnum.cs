using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamDatadogEnum.LogStreamDatadogEnumSerializer))]
[Serializable]
public readonly record struct LogStreamDatadogEnum : IStringEnum
{
    public static readonly LogStreamDatadogEnum Datadog = new(Values.Datadog);

    public LogStreamDatadogEnum(string value)
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
    public static LogStreamDatadogEnum FromCustom(string value)
    {
        return new LogStreamDatadogEnum(value);
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

    public static bool operator ==(LogStreamDatadogEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamDatadogEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamDatadogEnum value) => value.Value;

    public static explicit operator LogStreamDatadogEnum(string value) => new(value);

    internal class LogStreamDatadogEnumSerializer : JsonConverter<LogStreamDatadogEnum>
    {
        public override LogStreamDatadogEnum Read(
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
            return new LogStreamDatadogEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamDatadogEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LogStreamDatadogEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new LogStreamDatadogEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LogStreamDatadogEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Datadog = "datadog";
    }
}
