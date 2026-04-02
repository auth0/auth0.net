using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionTwilioSendSmsType.FlowActionTwilioSendSmsTypeSerializer))]
[Serializable]
public readonly record struct FlowActionTwilioSendSmsType : IStringEnum
{
    public static readonly FlowActionTwilioSendSmsType Twilio = new(Values.Twilio);

    public FlowActionTwilioSendSmsType(string value)
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
    public static FlowActionTwilioSendSmsType FromCustom(string value)
    {
        return new FlowActionTwilioSendSmsType(value);
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

    public static bool operator ==(FlowActionTwilioSendSmsType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionTwilioSendSmsType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionTwilioSendSmsType value) => value.Value;

    public static explicit operator FlowActionTwilioSendSmsType(string value) => new(value);

    internal class FlowActionTwilioSendSmsTypeSerializer
        : JsonConverter<FlowActionTwilioSendSmsType>
    {
        public override FlowActionTwilioSendSmsType Read(
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
            return new FlowActionTwilioSendSmsType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionTwilioSendSmsType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionTwilioSendSmsType ReadAsPropertyName(
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
            return new FlowActionTwilioSendSmsType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionTwilioSendSmsType value,
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
        public const string Twilio = "TWILIO";
    }
}
