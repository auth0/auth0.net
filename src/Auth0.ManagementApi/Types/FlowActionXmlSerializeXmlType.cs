using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionXmlSerializeXmlType.FlowActionXmlSerializeXmlTypeSerializer))]
[Serializable]
public readonly record struct FlowActionXmlSerializeXmlType : IStringEnum
{
    public static readonly FlowActionXmlSerializeXmlType Xml = new(Values.Xml);

    public FlowActionXmlSerializeXmlType(string value)
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
    public static FlowActionXmlSerializeXmlType FromCustom(string value)
    {
        return new FlowActionXmlSerializeXmlType(value);
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

    public static bool operator ==(FlowActionXmlSerializeXmlType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionXmlSerializeXmlType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionXmlSerializeXmlType value) => value.Value;

    public static explicit operator FlowActionXmlSerializeXmlType(string value) => new(value);

    internal class FlowActionXmlSerializeXmlTypeSerializer
        : JsonConverter<FlowActionXmlSerializeXmlType>
    {
        public override FlowActionXmlSerializeXmlType Read(
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
            return new FlowActionXmlSerializeXmlType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionXmlSerializeXmlType value,
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
        public const string Xml = "XML";
    }
}
