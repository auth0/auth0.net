using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionFlowDelayFlowParamsUnits.FlowActionFlowDelayFlowParamsUnitsSerializer)
)]
[Serializable]
public readonly record struct FlowActionFlowDelayFlowParamsUnits : IStringEnum
{
    public static readonly FlowActionFlowDelayFlowParamsUnits Seconds = new(Values.Seconds);

    public static readonly FlowActionFlowDelayFlowParamsUnits Minutes = new(Values.Minutes);

    public static readonly FlowActionFlowDelayFlowParamsUnits Hours = new(Values.Hours);

    public static readonly FlowActionFlowDelayFlowParamsUnits Days = new(Values.Days);

    public FlowActionFlowDelayFlowParamsUnits(string value)
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
    public static FlowActionFlowDelayFlowParamsUnits FromCustom(string value)
    {
        return new FlowActionFlowDelayFlowParamsUnits(value);
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

    public static bool operator ==(FlowActionFlowDelayFlowParamsUnits value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionFlowDelayFlowParamsUnits value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionFlowDelayFlowParamsUnits value) => value.Value;

    public static explicit operator FlowActionFlowDelayFlowParamsUnits(string value) => new(value);

    internal class FlowActionFlowDelayFlowParamsUnitsSerializer
        : JsonConverter<FlowActionFlowDelayFlowParamsUnits>
    {
        public override FlowActionFlowDelayFlowParamsUnits Read(
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
            return new FlowActionFlowDelayFlowParamsUnits(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionFlowDelayFlowParamsUnits value,
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
        public const string Seconds = "SECONDS";

        public const string Minutes = "MINUTES";

        public const string Hours = "HOURS";

        public const string Days = "DAYS";
    }
}
