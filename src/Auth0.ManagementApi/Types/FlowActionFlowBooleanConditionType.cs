using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionFlowBooleanConditionType.FlowActionFlowBooleanConditionTypeSerializer)
)]
[Serializable]
public readonly record struct FlowActionFlowBooleanConditionType : IStringEnum
{
    public static readonly FlowActionFlowBooleanConditionType Flow = new(Values.Flow);

    public FlowActionFlowBooleanConditionType(string value)
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
    public static FlowActionFlowBooleanConditionType FromCustom(string value)
    {
        return new FlowActionFlowBooleanConditionType(value);
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

    public static bool operator ==(FlowActionFlowBooleanConditionType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionFlowBooleanConditionType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionFlowBooleanConditionType value) => value.Value;

    public static explicit operator FlowActionFlowBooleanConditionType(string value) => new(value);

    internal class FlowActionFlowBooleanConditionTypeSerializer
        : JsonConverter<FlowActionFlowBooleanConditionType>
    {
        public override FlowActionFlowBooleanConditionType Read(
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
            return new FlowActionFlowBooleanConditionType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionFlowBooleanConditionType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionFlowBooleanConditionType ReadAsPropertyName(
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
            return new FlowActionFlowBooleanConditionType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionFlowBooleanConditionType value,
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
