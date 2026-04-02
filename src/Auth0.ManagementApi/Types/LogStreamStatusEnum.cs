using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamStatusEnum.LogStreamStatusEnumSerializer))]
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

    internal class LogStreamStatusEnumSerializer : JsonConverter<LogStreamStatusEnum>
    {
        public override LogStreamStatusEnum Read(
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
            return new LogStreamStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LogStreamStatusEnum ReadAsPropertyName(
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
            return new LogStreamStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LogStreamStatusEnum value,
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
        public const string Active = "active";

        public const string Paused = "paused";

        public const string Suspended = "suspended";
    }
}
