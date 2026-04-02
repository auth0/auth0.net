using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamWebhookCustomHeaderAuthMethodEnum.EventStreamWebhookCustomHeaderAuthMethodEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamWebhookCustomHeaderAuthMethodEnum : IStringEnum
{
    public static readonly EventStreamWebhookCustomHeaderAuthMethodEnum CustomHeader = new(
        Values.CustomHeader
    );

    public EventStreamWebhookCustomHeaderAuthMethodEnum(string value)
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
    public static EventStreamWebhookCustomHeaderAuthMethodEnum FromCustom(string value)
    {
        return new EventStreamWebhookCustomHeaderAuthMethodEnum(value);
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

    public static bool operator ==(
        EventStreamWebhookCustomHeaderAuthMethodEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamWebhookCustomHeaderAuthMethodEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamWebhookCustomHeaderAuthMethodEnum value) =>
        value.Value;

    public static explicit operator EventStreamWebhookCustomHeaderAuthMethodEnum(string value) =>
        new(value);

    internal class EventStreamWebhookCustomHeaderAuthMethodEnumSerializer
        : JsonConverter<EventStreamWebhookCustomHeaderAuthMethodEnum>
    {
        public override EventStreamWebhookCustomHeaderAuthMethodEnum Read(
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
            return new EventStreamWebhookCustomHeaderAuthMethodEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamWebhookCustomHeaderAuthMethodEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamWebhookCustomHeaderAuthMethodEnum ReadAsPropertyName(
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
            return new EventStreamWebhookCustomHeaderAuthMethodEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamWebhookCustomHeaderAuthMethodEnum value,
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
        public const string CustomHeader = "custom_header";
    }
}
