using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionXmlSerializeXmlAction.FlowActionXmlSerializeXmlActionSerializer))]
[Serializable]
public readonly record struct FlowActionXmlSerializeXmlAction : IStringEnum
{
    public static readonly FlowActionXmlSerializeXmlAction SerializeXml = new(Values.SerializeXml);

    public FlowActionXmlSerializeXmlAction(string value)
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
    public static FlowActionXmlSerializeXmlAction FromCustom(string value)
    {
        return new FlowActionXmlSerializeXmlAction(value);
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

    public static bool operator ==(FlowActionXmlSerializeXmlAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionXmlSerializeXmlAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionXmlSerializeXmlAction value) => value.Value;

    public static explicit operator FlowActionXmlSerializeXmlAction(string value) => new(value);

    internal class FlowActionXmlSerializeXmlActionSerializer
        : JsonConverter<FlowActionXmlSerializeXmlAction>
    {
        public override FlowActionXmlSerializeXmlAction Read(
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
            return new FlowActionXmlSerializeXmlAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionXmlSerializeXmlAction value,
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
        public const string SerializeXml = "SERIALIZE_XML";
    }
}
