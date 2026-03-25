using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionFlowDoNothingAction.FlowActionFlowDoNothingActionSerializer))]
[Serializable]
public readonly record struct FlowActionFlowDoNothingAction : IStringEnum
{
    public static readonly FlowActionFlowDoNothingAction DoNothing = new(Values.DoNothing);

    public FlowActionFlowDoNothingAction(string value)
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
    public static FlowActionFlowDoNothingAction FromCustom(string value)
    {
        return new FlowActionFlowDoNothingAction(value);
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

    public static bool operator ==(FlowActionFlowDoNothingAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionFlowDoNothingAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionFlowDoNothingAction value) => value.Value;

    public static explicit operator FlowActionFlowDoNothingAction(string value) => new(value);

    internal class FlowActionFlowDoNothingActionSerializer
        : JsonConverter<FlowActionFlowDoNothingAction>
    {
        public override FlowActionFlowDoNothingAction Read(
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
            return new FlowActionFlowDoNothingAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionFlowDoNothingAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionFlowDoNothingAction ReadAsPropertyName(
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
            return new FlowActionFlowDoNothingAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionFlowDoNothingAction value,
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
        public const string DoNothing = "DO_NOTHING";
    }
}
