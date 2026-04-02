using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamPiiMethodEnum.LogStreamPiiMethodEnumSerializer))]
[Serializable]
public readonly record struct LogStreamPiiMethodEnum : IStringEnum
{
    public static readonly LogStreamPiiMethodEnum Mask = new(Values.Mask);

    public static readonly LogStreamPiiMethodEnum Hash = new(Values.Hash);

    public LogStreamPiiMethodEnum(string value)
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
    public static LogStreamPiiMethodEnum FromCustom(string value)
    {
        return new LogStreamPiiMethodEnum(value);
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

    public static bool operator ==(LogStreamPiiMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamPiiMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamPiiMethodEnum value) => value.Value;

    public static explicit operator LogStreamPiiMethodEnum(string value) => new(value);

    internal class LogStreamPiiMethodEnumSerializer : JsonConverter<LogStreamPiiMethodEnum>
    {
        public override LogStreamPiiMethodEnum Read(
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
            return new LogStreamPiiMethodEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamPiiMethodEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LogStreamPiiMethodEnum ReadAsPropertyName(
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
            return new LogStreamPiiMethodEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LogStreamPiiMethodEnum value,
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
        public const string Mask = "mask";

        public const string Hash = "hash";
    }
}
