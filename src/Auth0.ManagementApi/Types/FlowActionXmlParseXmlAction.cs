using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionXmlParseXmlAction.FlowActionXmlParseXmlActionSerializer))]
[Serializable]
public readonly record struct FlowActionXmlParseXmlAction : IStringEnum
{
    public static readonly FlowActionXmlParseXmlAction ParseXml = new(Values.ParseXml);

    public FlowActionXmlParseXmlAction(string value)
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
    public static FlowActionXmlParseXmlAction FromCustom(string value)
    {
        return new FlowActionXmlParseXmlAction(value);
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

    public static bool operator ==(FlowActionXmlParseXmlAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionXmlParseXmlAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionXmlParseXmlAction value) => value.Value;

    public static explicit operator FlowActionXmlParseXmlAction(string value) => new(value);

    internal class FlowActionXmlParseXmlActionSerializer
        : JsonConverter<FlowActionXmlParseXmlAction>
    {
        public override FlowActionXmlParseXmlAction Read(
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
            return new FlowActionXmlParseXmlAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionXmlParseXmlAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionXmlParseXmlAction ReadAsPropertyName(
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
            return new FlowActionXmlParseXmlAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionXmlParseXmlAction value,
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
        public const string ParseXml = "PARSE_XML";
    }
}
