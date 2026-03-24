using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionTwilioMakeCallAction.FlowActionTwilioMakeCallActionSerializer))]
[Serializable]
public readonly record struct FlowActionTwilioMakeCallAction : IStringEnum
{
    public static readonly FlowActionTwilioMakeCallAction MakeCall = new(Values.MakeCall);

    public FlowActionTwilioMakeCallAction(string value)
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
    public static FlowActionTwilioMakeCallAction FromCustom(string value)
    {
        return new FlowActionTwilioMakeCallAction(value);
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

    public static bool operator ==(FlowActionTwilioMakeCallAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionTwilioMakeCallAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionTwilioMakeCallAction value) => value.Value;

    public static explicit operator FlowActionTwilioMakeCallAction(string value) => new(value);

    internal class FlowActionTwilioMakeCallActionSerializer
        : JsonConverter<FlowActionTwilioMakeCallAction>
    {
        public override FlowActionTwilioMakeCallAction Read(
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
            return new FlowActionTwilioMakeCallAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionTwilioMakeCallAction value,
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
        public const string MakeCall = "MAKE_CALL";
    }
}
