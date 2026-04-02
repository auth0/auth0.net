using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionWhatsappSendMessageType.FlowActionWhatsappSendMessageTypeSerializer)
)]
[Serializable]
public readonly record struct FlowActionWhatsappSendMessageType : IStringEnum
{
    public static readonly FlowActionWhatsappSendMessageType Whatsapp = new(Values.Whatsapp);

    public FlowActionWhatsappSendMessageType(string value)
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
    public static FlowActionWhatsappSendMessageType FromCustom(string value)
    {
        return new FlowActionWhatsappSendMessageType(value);
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

    public static bool operator ==(FlowActionWhatsappSendMessageType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionWhatsappSendMessageType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionWhatsappSendMessageType value) => value.Value;

    public static explicit operator FlowActionWhatsappSendMessageType(string value) => new(value);

    internal class FlowActionWhatsappSendMessageTypeSerializer
        : JsonConverter<FlowActionWhatsappSendMessageType>
    {
        public override FlowActionWhatsappSendMessageType Read(
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
            return new FlowActionWhatsappSendMessageType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionWhatsappSendMessageType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionWhatsappSendMessageType ReadAsPropertyName(
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
            return new FlowActionWhatsappSendMessageType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionWhatsappSendMessageType value,
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
        public const string Whatsapp = "WHATSAPP";
    }
}
