using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionFlowMapValueType.FlowActionFlowMapValueTypeSerializer))]
[Serializable]
public readonly record struct FlowActionFlowMapValueType : IStringEnum
{
    public static readonly FlowActionFlowMapValueType Flow = new(Values.Flow);

    public FlowActionFlowMapValueType(string value)
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
    public static FlowActionFlowMapValueType FromCustom(string value)
    {
        return new FlowActionFlowMapValueType(value);
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

    public static bool operator ==(FlowActionFlowMapValueType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionFlowMapValueType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionFlowMapValueType value) => value.Value;

    public static explicit operator FlowActionFlowMapValueType(string value) => new(value);

    internal class FlowActionFlowMapValueTypeSerializer : JsonConverter<FlowActionFlowMapValueType>
    {
        public override FlowActionFlowMapValueType Read(
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
            return new FlowActionFlowMapValueType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionFlowMapValueType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionFlowMapValueType ReadAsPropertyName(
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
            return new FlowActionFlowMapValueType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionFlowMapValueType value,
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
        public const string Flow = "FLOW";
    }
}
