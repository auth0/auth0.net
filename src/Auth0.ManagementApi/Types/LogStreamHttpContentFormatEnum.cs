using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamHttpContentFormatEnum.LogStreamHttpContentFormatEnumSerializer))]
[Serializable]
public readonly record struct LogStreamHttpContentFormatEnum : IStringEnum
{
    public static readonly LogStreamHttpContentFormatEnum Jsonarray = new(Values.Jsonarray);

    public static readonly LogStreamHttpContentFormatEnum Jsonlines = new(Values.Jsonlines);

    public static readonly LogStreamHttpContentFormatEnum Jsonobject = new(Values.Jsonobject);

    public LogStreamHttpContentFormatEnum(string value)
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
    public static LogStreamHttpContentFormatEnum FromCustom(string value)
    {
        return new LogStreamHttpContentFormatEnum(value);
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

    public static bool operator ==(LogStreamHttpContentFormatEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamHttpContentFormatEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamHttpContentFormatEnum value) => value.Value;

    public static explicit operator LogStreamHttpContentFormatEnum(string value) => new(value);

    internal class LogStreamHttpContentFormatEnumSerializer
        : JsonConverter<LogStreamHttpContentFormatEnum>
    {
        public override LogStreamHttpContentFormatEnum Read(
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
            return new LogStreamHttpContentFormatEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamHttpContentFormatEnum value,
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
        public const string Jsonarray = "JSONARRAY";

        public const string Jsonlines = "JSONLINES";

        public const string Jsonobject = "JSONOBJECT";
    }
}
