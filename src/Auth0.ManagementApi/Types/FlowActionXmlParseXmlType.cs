using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionXmlParseXmlType.FlowActionXmlParseXmlTypeSerializer))]
[Serializable]
public readonly record struct FlowActionXmlParseXmlType : IStringEnum
{
    public static readonly FlowActionXmlParseXmlType Xml = new(Values.Xml);

    public FlowActionXmlParseXmlType(string value)
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
    public static FlowActionXmlParseXmlType FromCustom(string value)
    {
        return new FlowActionXmlParseXmlType(value);
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

    public static bool operator ==(FlowActionXmlParseXmlType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionXmlParseXmlType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionXmlParseXmlType value) => value.Value;

    public static explicit operator FlowActionXmlParseXmlType(string value) => new(value);

    internal class FlowActionXmlParseXmlTypeSerializer : JsonConverter<FlowActionXmlParseXmlType>
    {
        public override FlowActionXmlParseXmlType Read(
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
            return new FlowActionXmlParseXmlType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionXmlParseXmlType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionXmlParseXmlType ReadAsPropertyName(
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
            return new FlowActionXmlParseXmlType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionXmlParseXmlType value,
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
        public const string Xml = "XML";
    }
}
