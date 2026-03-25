using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamWebhookDestinationTypeEnum.EventStreamWebhookDestinationTypeEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamWebhookDestinationTypeEnum : IStringEnum
{
    public static readonly EventStreamWebhookDestinationTypeEnum Webhook = new(Values.Webhook);

    public EventStreamWebhookDestinationTypeEnum(string value)
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
    public static EventStreamWebhookDestinationTypeEnum FromCustom(string value)
    {
        return new EventStreamWebhookDestinationTypeEnum(value);
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

    public static bool operator ==(EventStreamWebhookDestinationTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamWebhookDestinationTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamWebhookDestinationTypeEnum value) =>
        value.Value;

    public static explicit operator EventStreamWebhookDestinationTypeEnum(string value) =>
        new(value);

    internal class EventStreamWebhookDestinationTypeEnumSerializer
        : JsonConverter<EventStreamWebhookDestinationTypeEnum>
    {
        public override EventStreamWebhookDestinationTypeEnum Read(
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
            return new EventStreamWebhookDestinationTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamWebhookDestinationTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamWebhookDestinationTypeEnum ReadAsPropertyName(
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
            return new EventStreamWebhookDestinationTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamWebhookDestinationTypeEnum value,
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
        public const string Webhook = "webhook";
    }
}
