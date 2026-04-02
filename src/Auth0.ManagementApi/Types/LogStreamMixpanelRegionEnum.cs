using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamMixpanelRegionEnum.LogStreamMixpanelRegionEnumSerializer))]
[Serializable]
public readonly record struct LogStreamMixpanelRegionEnum : IStringEnum
{
    public static readonly LogStreamMixpanelRegionEnum Us = new(Values.Us);

    public static readonly LogStreamMixpanelRegionEnum Eu = new(Values.Eu);

    public LogStreamMixpanelRegionEnum(string value)
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
    public static LogStreamMixpanelRegionEnum FromCustom(string value)
    {
        return new LogStreamMixpanelRegionEnum(value);
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

    public static bool operator ==(LogStreamMixpanelRegionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamMixpanelRegionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamMixpanelRegionEnum value) => value.Value;

    public static explicit operator LogStreamMixpanelRegionEnum(string value) => new(value);

    internal class LogStreamMixpanelRegionEnumSerializer
        : JsonConverter<LogStreamMixpanelRegionEnum>
    {
        public override LogStreamMixpanelRegionEnum Read(
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
            return new LogStreamMixpanelRegionEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamMixpanelRegionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LogStreamMixpanelRegionEnum ReadAsPropertyName(
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
            return new LogStreamMixpanelRegionEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LogStreamMixpanelRegionEnum value,
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
        public const string Us = "us";

        public const string Eu = "eu";
    }
}
