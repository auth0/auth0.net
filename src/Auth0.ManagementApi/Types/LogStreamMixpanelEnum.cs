using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamMixpanelEnum.LogStreamMixpanelEnumSerializer))]
[Serializable]
public readonly record struct LogStreamMixpanelEnum : IStringEnum
{
    public static readonly LogStreamMixpanelEnum Mixpanel = new(Values.Mixpanel);

    public LogStreamMixpanelEnum(string value)
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
    public static LogStreamMixpanelEnum FromCustom(string value)
    {
        return new LogStreamMixpanelEnum(value);
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

    public static bool operator ==(LogStreamMixpanelEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamMixpanelEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamMixpanelEnum value) => value.Value;

    public static explicit operator LogStreamMixpanelEnum(string value) => new(value);

    internal class LogStreamMixpanelEnumSerializer : JsonConverter<LogStreamMixpanelEnum>
    {
        public override LogStreamMixpanelEnum Read(
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
            return new LogStreamMixpanelEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamMixpanelEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LogStreamMixpanelEnum ReadAsPropertyName(
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
            return new LogStreamMixpanelEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LogStreamMixpanelEnum value,
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
        public const string Mixpanel = "mixpanel";
    }
}
