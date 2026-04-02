using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionFlowDelayFlowAction.FlowActionFlowDelayFlowActionSerializer))]
[Serializable]
public readonly record struct FlowActionFlowDelayFlowAction : IStringEnum
{
    public static readonly FlowActionFlowDelayFlowAction DelayFlow = new(Values.DelayFlow);

    public FlowActionFlowDelayFlowAction(string value)
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
    public static FlowActionFlowDelayFlowAction FromCustom(string value)
    {
        return new FlowActionFlowDelayFlowAction(value);
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

    public static bool operator ==(FlowActionFlowDelayFlowAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionFlowDelayFlowAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionFlowDelayFlowAction value) => value.Value;

    public static explicit operator FlowActionFlowDelayFlowAction(string value) => new(value);

    internal class FlowActionFlowDelayFlowActionSerializer
        : JsonConverter<FlowActionFlowDelayFlowAction>
    {
        public override FlowActionFlowDelayFlowAction Read(
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
            return new FlowActionFlowDelayFlowAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionFlowDelayFlowAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionFlowDelayFlowAction ReadAsPropertyName(
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
            return new FlowActionFlowDelayFlowAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionFlowDelayFlowAction value,
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
        public const string DelayFlow = "DELAY_FLOW";
    }
}
