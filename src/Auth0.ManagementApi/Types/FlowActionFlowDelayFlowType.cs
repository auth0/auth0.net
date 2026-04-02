using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionFlowDelayFlowType.FlowActionFlowDelayFlowTypeSerializer))]
[Serializable]
public readonly record struct FlowActionFlowDelayFlowType : IStringEnum
{
    public static readonly FlowActionFlowDelayFlowType Flow = new(Values.Flow);

    public FlowActionFlowDelayFlowType(string value)
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
    public static FlowActionFlowDelayFlowType FromCustom(string value)
    {
        return new FlowActionFlowDelayFlowType(value);
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

    public static bool operator ==(FlowActionFlowDelayFlowType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionFlowDelayFlowType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionFlowDelayFlowType value) => value.Value;

    public static explicit operator FlowActionFlowDelayFlowType(string value) => new(value);

    internal class FlowActionFlowDelayFlowTypeSerializer
        : JsonConverter<FlowActionFlowDelayFlowType>
    {
        public override FlowActionFlowDelayFlowType Read(
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
            return new FlowActionFlowDelayFlowType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionFlowDelayFlowType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionFlowDelayFlowType ReadAsPropertyName(
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
            return new FlowActionFlowDelayFlowType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionFlowDelayFlowType value,
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
