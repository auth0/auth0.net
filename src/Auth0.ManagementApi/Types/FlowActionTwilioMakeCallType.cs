using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionTwilioMakeCallType.FlowActionTwilioMakeCallTypeSerializer))]
[Serializable]
public readonly record struct FlowActionTwilioMakeCallType : IStringEnum
{
    public static readonly FlowActionTwilioMakeCallType Twilio = new(Values.Twilio);

    public FlowActionTwilioMakeCallType(string value)
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
    public static FlowActionTwilioMakeCallType FromCustom(string value)
    {
        return new FlowActionTwilioMakeCallType(value);
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

    public static bool operator ==(FlowActionTwilioMakeCallType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionTwilioMakeCallType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionTwilioMakeCallType value) => value.Value;

    public static explicit operator FlowActionTwilioMakeCallType(string value) => new(value);

    internal class FlowActionTwilioMakeCallTypeSerializer
        : JsonConverter<FlowActionTwilioMakeCallType>
    {
        public override FlowActionTwilioMakeCallType Read(
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
            return new FlowActionTwilioMakeCallType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionTwilioMakeCallType value,
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
        public const string Twilio = "TWILIO";
    }
}
