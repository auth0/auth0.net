using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamSplunkEnum.LogStreamSplunkEnumSerializer))]
[Serializable]
public readonly record struct LogStreamSplunkEnum : IStringEnum
{
    public static readonly LogStreamSplunkEnum Splunk = new(Values.Splunk);

    public LogStreamSplunkEnum(string value)
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
    public static LogStreamSplunkEnum FromCustom(string value)
    {
        return new LogStreamSplunkEnum(value);
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

    public static bool operator ==(LogStreamSplunkEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamSplunkEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamSplunkEnum value) => value.Value;

    public static explicit operator LogStreamSplunkEnum(string value) => new(value);

    internal class LogStreamSplunkEnumSerializer : JsonConverter<LogStreamSplunkEnum>
    {
        public override LogStreamSplunkEnum Read(
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
            return new LogStreamSplunkEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamSplunkEnum value,
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
        public const string Splunk = "splunk";
    }
}
