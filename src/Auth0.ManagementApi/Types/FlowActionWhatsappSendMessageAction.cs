using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionWhatsappSendMessageAction.FlowActionWhatsappSendMessageActionSerializer)
)]
[Serializable]
public readonly record struct FlowActionWhatsappSendMessageAction : IStringEnum
{
    public static readonly FlowActionWhatsappSendMessageAction SendMessage = new(
        Values.SendMessage
    );

    public FlowActionWhatsappSendMessageAction(string value)
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
    public static FlowActionWhatsappSendMessageAction FromCustom(string value)
    {
        return new FlowActionWhatsappSendMessageAction(value);
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

    public static bool operator ==(FlowActionWhatsappSendMessageAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionWhatsappSendMessageAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionWhatsappSendMessageAction value) =>
        value.Value;

    public static explicit operator FlowActionWhatsappSendMessageAction(string value) => new(value);

    internal class FlowActionWhatsappSendMessageActionSerializer
        : JsonConverter<FlowActionWhatsappSendMessageAction>
    {
        public override FlowActionWhatsappSendMessageAction Read(
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
            return new FlowActionWhatsappSendMessageAction(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionWhatsappSendMessageAction value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionWhatsappSendMessageAction ReadAsPropertyName(
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
            return new FlowActionWhatsappSendMessageAction(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionWhatsappSendMessageAction value,
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
        public const string SendMessage = "SEND_MESSAGE";
    }
}
